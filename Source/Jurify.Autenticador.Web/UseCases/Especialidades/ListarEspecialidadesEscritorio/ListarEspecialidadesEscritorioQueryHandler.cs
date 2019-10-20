using Jurify.Autenticador.Web.UseCases.Advogados.ListarUsuariosDoEscritorio;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Jurify.Autenticador.Web.Domain.Model.Entities;

namespace Jurify.Autenticador.Web.UseCases.Specialties.ListSpecialties
{
    public class ListarEspecialidadesEscritorioQueryHandler : IRequestHandler<ListarEspecialidadesEscritorioQuery, Response<List<EspecialidadesEscritorio>>>
    {
        private readonly AutenticadorContext _context;

        public ListarEspecialidadesEscritorioQueryHandler(AutenticadorContext context)
        {
            _context = context;
        }

        public async Task<Response<List<EspecialidadesEscritorio>>> Handle(ListarEspecialidadesEscritorioQuery request, CancellationToken cancellationToken)
        {
            var especialidadesEscritorio = await _context
                .EspecialidadesEscritorio
                .Where(u => u.CodigoEscritorio == request.CodigoEscritorio).ToListAsync();
            List<EspecialidadesEscritorio> especialidadesDetalhes = new List<EspecialidadesEscritorio>();
            if (especialidadesEscritorio == null)
                return Response<List<EspecialidadesEscritorio>>.WithErrors("Especialidades não encontradas");
            foreach (var obj in especialidadesEscritorio) {
                var especialidade = await _context.Especialidades.FirstOrDefaultAsync(e => e.Codigo == obj.CodigoEspecialidade);
                obj.Nome = especialidade.Nome;
                obj.Descricao = especialidade.Descricao;
                especialidadesDetalhes.Add(obj);
            }
            return Response<List<EspecialidadesEscritorio>>.WithResult(especialidadesDetalhes);
        }
    }
}
