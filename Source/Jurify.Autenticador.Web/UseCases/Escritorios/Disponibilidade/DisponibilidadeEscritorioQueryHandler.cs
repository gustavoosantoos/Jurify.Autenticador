using System.Threading;
using System.Threading.Tasks;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Jurify.Autenticador.Web.UseCases.Offices.Availability
{
    public class DisponibilidadeEscritorioQueryHandler : IRequestHandler<DisponibilidadeEscritorioQuery, Response<bool>>
    {
        private readonly AutenticadorContext _context;

        public DisponibilidadeEscritorioQueryHandler(AutenticadorContext context)
        {
            _context = context;
        }

        public async Task<Response<bool>> Handle(DisponibilidadeEscritorioQuery request, CancellationToken cancellationToken)
        {
            var existsOfficeWithSameName = await _context.Escritorios.AnyAsync(o => o.Informacoes.NomeFantasia == request.NomeFantasia);
            return Response<bool>.WithResult(!existsOfficeWithSameName);
        }
    }
}
