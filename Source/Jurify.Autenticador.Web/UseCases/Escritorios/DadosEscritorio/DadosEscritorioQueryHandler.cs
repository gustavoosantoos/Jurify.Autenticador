using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.Domain.Model.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jurify.Autenticador.Web.UseCases.Core;

namespace Jurify.Autenticador.Web.UseCases.Offices.ListOffices
{
    public class DadosEscritorioQueryHandler : IRequestHandler<DadosEscritorioQuery, Response<Escritorio>>
    {
        private readonly AutenticadorContext _context;

        public DadosEscritorioQueryHandler(AutenticadorContext context)
        {
            _context = context;
        }

        public async Task<Response<Escritorio>> Handle(DadosEscritorioQuery request, CancellationToken cancellationToken)
        {
            var escritorio = await _context
                .Escritorios.Include(e => e.Endereco)
                .FirstOrDefaultAsync(u => u.Codigo == request.CodigoEscritorio);

            if (escritorio == null)
                return Response<Escritorio>.WithErrors("Usuário não encontrado");

          
            return Response<Escritorio>.WithResult(escritorio);
        }
    }
}
