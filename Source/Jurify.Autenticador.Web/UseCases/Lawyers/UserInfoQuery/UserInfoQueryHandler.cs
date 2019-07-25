using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.UserInfoQuery
{
    public class UserInfoQueryHandler : IRequestHandler<UserInfoQuery, Response<OfficeUser>>
    {
        private readonly AutenticadorContext _context;

        public UserInfoQueryHandler(AutenticadorContext context)
        {
            _context = context;
        }

        public async Task<Response<OfficeUser>> Handle(UserInfoQuery request, CancellationToken cancellationToken)
        {
            var user = await _context
                .OfficeUsers
                .Include(u => u.Office)
                .FirstOrDefaultAsync(u => u.Id == request.UserId && u.OfficeId == request.OfficeId);

            if (user == null)
                return Response<OfficeUser>.WithErrors("Usuário não encontrado");

            return Response<OfficeUser>.WithResult(user);
        }
    }
}
