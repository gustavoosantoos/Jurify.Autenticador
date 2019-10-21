using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Domain.Model.Services.Abstractions;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.UseCases.Core;
using Jurify.Autenticador.Web.UseCases.Specialties.Create;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.UseCases.Specialties.RemoveOfficeSpecialty
{
    public class RemoverEspecialidadeEscritorioCommandHandler : IRequestHandler<RemoverEspecialidadeEscritorioCommand, Response<EspecialidadesEscritorio>>
    {
        private readonly AutenticadorContext _context;
        private readonly IMediator _mediator;
        private readonly IHashService _hashService;

        public RemoverEspecialidadeEscritorioCommandHandler(
            AutenticadorContext context,
            IMediator mediator,
            IHashService hashService)
        {
            _context = context;
            _mediator = mediator;
            _hashService = hashService;
        }

        public async Task<Response<EspecialidadesEscritorio>> Handle(RemoverEspecialidadeEscritorioCommand request, CancellationToken cancellationToken)
        {
            var result = Response<EspecialidadesEscritorio>.WithResult(null);
            var existsAlredy = await _context.EspecialidadesEscritorio.AnyAsync(u => u.Codigo == request.CodigoEspecialidadeEscritorio);

            if (!existsAlredy)
            {
                result.AddError("Não existe uma especialidade com este codigo, utilize outro codigo.");
                return result;
            }

            var especialidade = await _context.EspecialidadesEscritorio.FirstOrDefaultAsync(u => u.Codigo == request.CodigoEspecialidadeEscritorio);

            _context.EspecialidadesEscritorio.Remove(especialidade);
            await _context.SaveChangesAsync();

            return Response<EspecialidadesEscritorio>.WithResult(especialidade);
        }


    }
}
