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
using System.Linq;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.ValidateOab
{
    public class ValidarOabCommandHandler : IRequestHandler<ValidarOabCommand, Response<OabValidada>>
    {
        private readonly AutenticadorContext _context;
        private readonly IMediator _mediator;
        private readonly IHashService _hashService;


        public ValidarOabCommandHandler(
            AutenticadorContext context,
            IMediator mediator,
            IHashService hashService)
        {
            _context = context;
            _mediator = mediator;
            _hashService = hashService;
        }

        public async Task<Response<OabValidada>> Handle(ValidarOabCommand request, CancellationToken cancellationToken)
        {
            OabValidada oab = new OabValidada(request.CodigoAdvogado, request.Uf, request.NumeroOab, request.CaminhoImagem, request.Ativo, request.Existe);
            var result = Response<OabValidada>.WithResult(null);
            CredenciaisAdvogado novasCredenciais = new CredenciaisAdvogado();
            var users = _context.UsuariosEscritorio
                .Where(u => u.Credenciais.NumeroOab == request.NumeroOab).ToList();
            if (users == null)
            {
                result.AddError("Usuario não encontrado para modificar");
                return result;
            }

            foreach(var user in users)
            {
                novasCredenciais = new CredenciaisAdvogado(request.NumeroOab, EstadoBrasileiro.ObterPorUF(request.Uf), request.CaminhoImagem);
                user.Credenciais = novasCredenciais;
                Permissao permissao = new Permissao("OabValida", "true");
                bool existePermissao = user.Permissoes.Any(p => p.Nome == "OabValida");
                if (!existePermissao)
                    user.Permissoes.Add(permissao);

                _context.UsuariosEscritorio.Update(user);
                await _context.SaveChangesAsync();
            }
            
            return Response<OabValidada>.WithResult(oab);
        }


    }
}
