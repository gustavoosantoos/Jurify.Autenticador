using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Offices.Create
{
    public class CreateOfficeCommandHandler : IRequestHandler<CreateOfficeCommand, Response<Guid>>
    {
        private readonly AutenticadorContext _context;

        public CreateOfficeCommandHandler(AutenticadorContext context)
        {
            _context = context;
        }

        public async Task<Response<Guid>> Handle(CreateOfficeCommand request, CancellationToken cancellationToken)
        {
            var existsOfficeWithSameName = await _context.Offices.AnyAsync(o => o.Info.Name == request.OfficeName);

            if (existsOfficeWithSameName)
            {
                return Response<Guid>.WithErrors("Já existe um escritório com o mesmo nome");
            }

            var office = request.AsOffice();

            await _context.Offices.AddAsync(office);
            await _context.SaveChangesAsync();
            
            return Response<Guid>.WithResult(office.Id);
        }
    }
}
