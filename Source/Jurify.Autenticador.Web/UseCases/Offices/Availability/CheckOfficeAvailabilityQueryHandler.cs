using System.Threading;
using System.Threading.Tasks;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jurify.Autenticador.Web.UseCases.Offices.Availability
{
    public class CheckOfficeAvailabilityQueryHandler : IRequestHandler<CheckOfficeAvailabilityQuery, Response<bool>>
    {
        private readonly AutenticadorContext _context;

        public CheckOfficeAvailabilityQueryHandler(AutenticadorContext context)
        {
            _context = context;
        }

        public async Task<Response<bool>> Handle(CheckOfficeAvailabilityQuery request, CancellationToken cancellationToken)
        {
            var existsOfficeWithSameName = await _context.Offices.AnyAsync(o => o.Info.Name == request.OfficeName);
            return Response<bool>.WithResult(!existsOfficeWithSameName);
        }
    }
}
