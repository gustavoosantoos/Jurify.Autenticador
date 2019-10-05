using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Lawyers.UserInfoQuery
{
    public class ListarUsuariosDoEscritorioQueryHandler : IRequestHandler<ListarUsuariosDoEscritorioQuery, Response<List<UsuarioEscritorio>>>
    {
        private readonly AutenticadorContext _context;

        public ListarUsuariosDoEscritorioQueryHandler(AutenticadorContext context)
        {
            _context = context;
        }

        public async Task<Response<List<UsuarioEscritorio>>> Handle(ListarUsuariosDoEscritorioQuery request, CancellationToken cancellationToken)
        {
            var user = await _context
                .UsuariosEscritorio
                .Where(u => u.CodigoEscritorio == request.CodigoEscritorio).ToListAsync();

            if (user == null)
                return Response<List<UsuarioEscritorio>>.WithErrors("Usuário não encontrado");

            return Response<List<UsuarioEscritorio>>.WithResult(user);
        }
    }
}
