using Jurify.Autenticador.Web.Domain.Model.Services.Abstractions;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.UseCases.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using EspecialidadesEscritorio = Jurify.Autenticador.Web.Domain.Model.Entities.EspecialidadesEscritorio;

namespace Jurify.Autenticador.Web.UseCases.Specialties.CreateOfficeSpecialty
{
    public class CriarEspecialidadeEscritorioCommandHandler : IRequestHandler<CriarEspecialidadeEscritorioCommand, Response<EspecialidadesEscritorio>>
    {
        private readonly AutenticadorContext _context;
        private readonly IMediator _mediator;
        private readonly IHashService _hashService;

        public CriarEspecialidadeEscritorioCommandHandler(
            AutenticadorContext context,
            IMediator mediator,
            IHashService hashService)
        {
            _context = context;
            _mediator = mediator;
            _hashService = hashService;
        }

        public async Task<Response<EspecialidadesEscritorio>> Handle(CriarEspecialidadeEscritorioCommand request, CancellationToken cancellationToken)
        {
            var result = Response<EspecialidadesEscritorio>.WithResult(null);
            var escritorioAtual = await _context.Escritorios.FirstOrDefaultAsync(o => o.Codigo == request.CodigoEscritorio);
            var especialidade = await _context.Especialidades.FirstOrDefaultAsync(e => e.Codigo == request.CodigoEspecialidade);
            var existsAlredy = await _context.EspecialidadesEscritorio.AnyAsync(u => u.CodigoEscritorio == escritorioAtual.Codigo && u.CodigoEspecialidade == especialidade.Codigo);

            if (existsAlredy)
            {
                result.AddError("Já existe uma especialidade com o mesmo nome, utilize outro nome.");
                return result;
            }

            var especialidadesEscritorio = new EspecialidadesEscritorio(especialidade.Codigo, escritorioAtual.Codigo
                );

            await _context.EspecialidadesEscritorio.AddAsync(especialidadesEscritorio);
            await _context.SaveChangesAsync();

            return Response<EspecialidadesEscritorio>.WithResult(especialidadesEscritorio);
        }


    }
}
