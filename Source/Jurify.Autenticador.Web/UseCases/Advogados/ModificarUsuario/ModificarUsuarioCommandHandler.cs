using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Domain.Model.Enums;
using Jurify.Autenticador.Web.Domain.Model.Services.Abstractions;
using Jurify.Autenticador.Web.Domain.Model.ValueObjects;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial;
using Jurify.Autenticador.Web.UseCases.Core;
using Jurify.Autenticador.Web.UseCases.Offices.Create;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.Modify
{
    public class ModificarUsuarioCommandHandler : IRequestHandler<ModificarUsuarioCommand, Response<UsuarioEscritorio>>
    {
        private readonly AutenticadorContext _context;
        private readonly IMediator _mediator;
        private readonly IHashService _hashService;


        public ModificarUsuarioCommandHandler(
            AutenticadorContext context,
            IMediator mediator,
            IHashService hashService)
        {
            _context = context;
            _mediator = mediator;
            _hashService = hashService;
        }

        public async Task<Response<UsuarioEscritorio>> Handle(ModificarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var result = Response<UsuarioEscritorio>.WithResult(null);
            CredenciaisAdvogado novasCredenciais = new CredenciaisAdvogado();
            var user = await _context.UsuariosEscritorio
                .FirstOrDefaultAsync(u => u.Codigo == request.Usuario.CodigoUsuario);

            if (user == null)
            {
                result.AddError("Usuario não encontrado para modificar");
                return result;
            }

            if (user.Credenciais != null && user.Credenciais.CaminhoFoto != null && !user.Credenciais.CaminhoFoto.Equals(""))
                novasCredenciais = new CredenciaisAdvogado(request.Usuario.NumeroOAB, EstadoBrasileiro.ObterPorCodigo(request.Usuario.Estado), user.Credenciais.CaminhoFoto);
            else
                novasCredenciais = new CredenciaisAdvogado(request.Usuario.NumeroOAB, EstadoBrasileiro.ObterPorCodigo(request.Usuario.Estado), "");

            user.Credenciais = novasCredenciais;
            user.AtualizarSenha(_hashService.Hash(request.Usuario.Senha));
            user.AtualizarInformacoesPessoais(new InformacoesPessoais(request.Usuario.Nome, request.Usuario.Sobrenome));

            _context.UsuariosEscritorio.Update(user);
            await _context.SaveChangesAsync();

            return Response<UsuarioEscritorio>.WithResult(user);
        }


    }
}
