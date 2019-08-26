using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Domain.Model.Services.Abstractions;
using Jurify.Autenticador.Web.Domain.Model.ValueObjects;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
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

        public CriarUsuarioInicialCommandHandler(
            AutenticadorContext context,
            IMediator mediator,
            IHashService hashService)
        {
            _context = context;
            _mediator = mediator;
            _hashService = hashService;
        }

        public async Task<Response<UsuarioEscritorio>> Handle(CriarUsuarioInicialCommand request, CancellationToken cancellationToken)
        {
            var result = Response<UsuarioEscritorio>.WithResult(null);
            var existsUserWithSameUsername = await _context.OfficeUsers.AnyAsync(u => u.Username == request.Usuario.Email);

            if (existsUserWithSameUsername)
            {
                result.AddError("Já existe um usuário com o mesmo e-mail, logue-se ou utilize outro e-mail");
            }

            var resultCreateOffice = await _mediator.Send(request.CriarEscritorioCommand());

            if (resultCreateOffice.IsFailure)
                result.AddErrors(resultCreateOffice.Errors);

            if (result.IsFailure)
                return result;

            UsuarioEscritorio user = new UsuarioEscritorio(
                resultCreateOffice.Result,
                request.Usuario.Email,
                _hashService.Hash(request.Usuario.Senha),
                new InformacoesPessoais(request.Usuario.Nome, request.Usuario.Sobrenome),
                new List<Permissao>()
            );

            await _context.OfficeUsers.AddAsync(user);
            await _context.SaveChangesAsync();

            return Response<UsuarioEscritorio>.WithResult(user);
        }
    }
}
