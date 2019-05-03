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
    public class CreateInitialLawyerCommandHandler : IRequestHandler<CreateInitialLawyerCommand, Response<OfficeUser>>
    {
        private readonly AutenticadorContext _context;
        private readonly IMediator _mediator;
        private readonly IHashService _hashService;

        public CreateInitialLawyerCommandHandler(
            AutenticadorContext context,
            IMediator mediator,
            IHashService hashService)
        {
            _context = context;
            _mediator = mediator;
            _hashService = hashService;
        }

        public async Task<Response<OfficeUser>> Handle(CreateInitialLawyerCommand request, CancellationToken cancellationToken)
        {
            var result = Response<OfficeUser>.WithResult(null);
            var existsUserWithSameUsername = await _context.OfficeUsers.AnyAsync(u => u.Username == request.Username);

            if (existsUserWithSameUsername)
            {
                result.AddError("Já existe um usuário com o mesmo e-mail, logue-se ou utilize outro e-mail");
            }

            var resultCreateOffice = await _mediator.Send(request.CreateOfficeCommand);

            if (resultCreateOffice.IsFailure)
                result.AddErrors(resultCreateOffice.Errors);

            if (result.IsFailure)
                return result;

            OfficeUser user = new OfficeUser(
                resultCreateOffice.Result,
                request.Username,
                _hashService.Hash(request.PlainPassword),
                new ContactInfo(new ContactEmail(request.Username)),
                new PersonalInfo(request.FirstName, request.LastName),
                new List<Claim>()
            );

            await _context.OfficeUsers.AddAsync(user);
            await _context.SaveChangesAsync();

            return Response<OfficeUser>.WithResult(user);
        }
    }
}
