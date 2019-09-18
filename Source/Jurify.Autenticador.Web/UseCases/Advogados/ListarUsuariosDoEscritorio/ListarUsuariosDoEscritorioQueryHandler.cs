using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.UserInfoQuery
{
    public class ListarUsuariosDoEscritorioQueryHandler : IRequestHandler<ListarUsuariosDoEscritorioQuery, Response<UsuarioEscritorio>>
    {
        private readonly AutenticadorContext _context;

        public ListarUsuariosDoEscritorioQueryHandler(AutenticadorContext context)
        {
            _context = context;
        }

        public async Task<Response<UsuarioEscritorio>> Handle(ListarUsuariosDoEscritorioQuery request, CancellationToken cancellationToken)
        {
            var user = await _context
                .UsuariosEscritorio
                .Include(u => u.Credenciais)
                .FirstOrDefaultAsync(u => u.CodigoEscritorio == request.CodigoEscritorio);

            if (user == null)
                return Response<UsuarioEscritorio>.WithErrors("Usuário não encontrado");

            return Response<UsuarioEscritorio>.WithResult(user);
        }
    }
}
