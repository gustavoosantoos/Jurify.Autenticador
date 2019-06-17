using System.Threading;
using System.Threading.Tasks;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.Availability
{
    public class CheckLawyerAvailabilityQueryHandler : IRequestHandler<CheckLawyerAvailabilityQuery, Response<bool>>
    {
        private readonly AutenticadorContext _context;

        public CheckLawyerAvailabilityQueryHandler(AutenticadorContext context)
        {
            _context = context;
        }

        public async Task<Response<bool>> Handle(CheckLawyerAvailabilityQuery request, CancellationToken cancellationToken)
        {
            var existsUserWithSameUsername = await _context.OfficeUsers.AnyAsync(u => u.Username == request.Username);
            return Response<bool>.WithResult(!existsUserWithSameUsername);
        }
    }
}
