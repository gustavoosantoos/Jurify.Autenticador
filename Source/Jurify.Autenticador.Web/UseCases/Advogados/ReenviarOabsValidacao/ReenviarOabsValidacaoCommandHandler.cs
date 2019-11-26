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

namespace Jurify.Autenticador.Web.UseCases.Lawyers.ResendValidateOab
{
    public class ReenviarOabsValidacaoCommandHandler : IRequestHandler<ReenviarOabsValidacaoCommand, Response<List<Oab>>>
    {
        private readonly AutenticadorContext _context;
        private readonly PerfilOabContext _oabContext;
        private readonly IMediator _mediator;
        private readonly IHashService _hashService;


        public ReenviarOabsValidacaoCommandHandler(
            AutenticadorContext context,
            PerfilOabContext oabContext,
            IMediator mediator,
            IHashService hashService)
        {
            _context = context;
            _oabContext = oabContext;
            _mediator = mediator;
            _hashService = hashService;
        }

        public async Task<Response<List<Oab>>> Handle(ReenviarOabsValidacaoCommand request, CancellationToken cancellationToken)
        {
            var result = Response<Oab>.WithResult(null);
            CredenciaisAdvogado novasCredenciais = new CredenciaisAdvogado();
            var users = _context.UsuariosEscritorio;
            Oab oabSaida;
            List<Oab> oabs = new List<Oab>();
            foreach ( var user in users)
            {
                oabSaida = new Oab(user.Codigo, user.Credenciais.NumeroOab, user.Credenciais.Estado.UF, $"{user.InformacoesPessoais.PrimeiroNome} {user.InformacoesPessoais.UltimoNome}");
                oabs.Add(oabSaida);
                ReenviarOabsValidacaoPublish.Publish(oabSaida);
            }

            return Response<List<Oab>>.WithResult(oabs);
        }


    }
}
