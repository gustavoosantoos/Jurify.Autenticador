using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Domain.Model.Enums;
using Jurify.Autenticador.Web.Domain.Model.Services.Abstractions;
using Jurify.Autenticador.Web.Domain.Model.ValueObjects;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.UseCases.Advogados.CriarUsuarioInicial;
using Jurify.Autenticador.Web.UseCases.Core;
using Jurify.Autenticador.Web.UseCases.Offices.Create;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial
{
    public class CriarUsuarioInicialCommandHandler : IRequestHandler<CriarUsuarioInicialCommand, Response<UsuarioEscritorio>>
    {
        private readonly AutenticadorContext _context;
        private readonly IMediator _mediator;
        private readonly IHashService _hashService;
        private readonly IGeocodingService _geocodingService;

        public CriarUsuarioInicialCommandHandler(
            AutenticadorContext context,
            IMediator mediator,
            IHashService hashService,
            IGeocodingService geocodingService)
        {
            _context = context;
            _mediator = mediator;
            _hashService = hashService;
            _geocodingService = geocodingService;
        }

        public async Task<Response<UsuarioEscritorio>> Handle(CriarUsuarioInicialCommand request, CancellationToken cancellationToken)
        {
            var result = Response<UsuarioEscritorio>.WithResult(null);
            var existsUserWithSameUsername = await _context.UsuariosEscritorio.AnyAsync(u => u.Username == request.Usuario.Email);

            if (existsUserWithSameUsername)
            {
                result.AddError("Já existe um usuário com o mesmo e-mail, logue-se ou utilize outro e-mail");
                return result;
            }

            var resultadoCriacaoEscritorio = await CriarEscritorio(request.CriarEscritorioCommand());

            if (resultadoCriacaoEscritorio.IsFailure)
                result.AddErrors(resultadoCriacaoEscritorio.Errors);

            if (result.IsFailure)
                return result;

            CredenciaisAdvogado credenciais = new CredenciaisAdvogado();
            Oab oabSaida = new Oab();

            if (request.Usuario.NumeroOAB != null && request.Usuario.Estado != 0)
            {
                credenciais = new CredenciaisAdvogado(
                    request.Usuario.NumeroOAB,
                    EstadoBrasileiro.ObterPorCodigo(request.Usuario.Estado),
                    null
                );
            }

            UsuarioEscritorio user = new UsuarioEscritorio(
                resultadoCriacaoEscritorio.Result,
                request.Usuario.Email,
                _hashService.Hash(request.Usuario.Senha),
                new InformacoesPessoais(request.Usuario.Nome, request.Usuario.Sobrenome),
                new List<Permissao>() {
                    new Permissao("EhAdministrador", "true")
                },
                credenciais
            );
            if (request.Usuario.NumeroOAB != null && request.Usuario.Estado != 0)
            {
                oabSaida = new Oab(user.Codigo, request.Usuario.NumeroOAB, EstadoBrasileiro.ObterPorCodigo(request.Usuario.Estado).UF, $"{request.Usuario.Nome} {request.Usuario.Sobrenome}");
                CriarUsuarioInicialCommandMessage.Publish(oabSaida);
            }

            await _context.UsuariosEscritorio.AddAsync(user);
            await _context.SaveChangesAsync();

            return Response<UsuarioEscritorio>.WithResult(user);
        }

        public async Task<Response<Guid>> CriarEscritorio(CriarEscritorioCommand command)
        {
            var existsOfficeWithSameName = await _context.Escritorios
           .AnyAsync(o => o.Informacoes.RazaoSocial == command.RazaoSocial ||
                          o.Informacoes.CNPJ == command.CNPJ);

            if (existsOfficeWithSameName)
            {
                return Response<Guid>.WithErrors("Já existe um escritório com a mesma razão social ou CNPJ");
            }

            var office = await command.AsOffice(_geocodingService);

            await _context.Escritorios.AddAsync(office);

            return Response<Guid>.WithResult(office.Codigo);
        }
    }
}
