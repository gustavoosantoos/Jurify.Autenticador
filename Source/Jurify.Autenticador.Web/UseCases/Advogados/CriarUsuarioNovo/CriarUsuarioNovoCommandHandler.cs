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
    public class CriarUsuarioNovoCommandHandler : IRequestHandler<CriarUsuarioNovoCommand, Response<UsuarioEscritorio>>
    {
        private readonly AutenticadorContext _context;
        private readonly PerfilOabContext _oabContext;
        private readonly IMediator _mediator;
        private readonly IHashService _hashService;

        public CriarUsuarioNovoCommandHandler(
            AutenticadorContext context,
            PerfilOabContext oabContext,
            IMediator mediator,
            IHashService hashService)
        {
            _oabContext = oabContext;
            _context = context;
            _mediator = mediator;
            _hashService = hashService;
        }

        public async Task<Response<UsuarioEscritorio>> Handle(CriarUsuarioNovoCommand request, CancellationToken cancellationToken)
        {
            var result = Response<UsuarioEscritorio>.WithResult(null);
            var existsUserWithSameUsername = await _context.UsuariosEscritorio.AnyAsync(u => u.Username == request.Usuario.Email);
            var escritorioAtual = await _context.Escritorios.FirstOrDefaultAsync(o => o.Informacoes.NomeFantasia == request.Escritorio.NomeFantasia);
            string ehAdministrador = "false";
            if (request.Usuario.ehAdministrador != null && !request.Usuario.ehAdministrador.Equals(""))
                 ehAdministrador = request.Usuario.ehAdministrador;

            if (escritorioAtual == null)
            {
                result.AddError("Escritorio não encontrado.");
                return result;
            }

            if (existsUserWithSameUsername)
            {
                result.AddError("Já existe um usuário com o mesmo e-mail, logue-se ou utilize outro e-mail");
                return result;
            }

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
                escritorioAtual.Codigo,
                request.Usuario.Email,
                _hashService.Hash(request.Usuario.Senha),
                new InformacoesPessoais(request.Usuario.Nome, request.Usuario.Sobrenome),
                new List<Permissao>() {
                    new Permissao("EhAdministrador", ehAdministrador)
                },
                credenciais
            );
            if (request.Usuario.NumeroOAB != null && request.Usuario.Estado != 0)
            {
                oabSaida = new Oab(user.Codigo, request.Usuario.NumeroOAB, EstadoBrasileiro.ObterPorCodigo(request.Usuario.Estado).UF, $"{request.Usuario.Nome} {request.Usuario.Sobrenome}");
                //CriarUsuarioInicialCommandMessage.Publish(oabSaida);
                await _oabContext.Oab.AddAsync(oabSaida);
                await _oabContext.SaveChangesAsync();
            };

                await _context.UsuariosEscritorio.AddAsync(user);
            await _context.SaveChangesAsync();

            return Response<UsuarioEscritorio>.WithResult(user);
        }


    }
}
