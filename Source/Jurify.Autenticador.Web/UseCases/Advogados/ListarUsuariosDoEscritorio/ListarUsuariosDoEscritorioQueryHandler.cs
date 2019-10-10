using Jurify.Autenticador.Web.UseCases.Advogados.ListarUsuariosDoEscritorio;
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
    public class ListarUsuariosDoEscritorioQueryHandler : IRequestHandler<ListarUsuariosDoEscritorioQuery, Response<List<Usuario>>>
    {
        private readonly AutenticadorContext _context;

        public ListarUsuariosDoEscritorioQueryHandler(AutenticadorContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Usuario>>> Handle(ListarUsuariosDoEscritorioQuery request, CancellationToken cancellationToken)
        {
            var users = await _context
                .UsuariosEscritorio
                .Where(u => u.Office.Informacoes.CNPJ == request.Cnpj).ToListAsync();

            if (users == null)
                return Response<List<Usuario>>.WithErrors("Usuário não encontrado");

            List<Usuario> usuarios = new List<Usuario>();

            foreach (var user in users)
            {
                usuarios.Add(new Usuario(user));
            }
            return Response<List<Usuario>>.WithResult(usuarios);
        }
    }
}
