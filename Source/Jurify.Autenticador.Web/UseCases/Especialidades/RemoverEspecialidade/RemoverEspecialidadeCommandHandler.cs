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

namespace Jurify.Autenticador.Web.UseCases.Specialties.RemoveSpecialty
{
    public class RemoverEspecialidadeCommandHandler : IRequestHandler<RemoverEspecialidadeCommand, Response<Especialidade>>
    {
        private readonly AutenticadorContext _context;
        private readonly IMediator _mediator;
        private readonly IHashService _hashService;

        public RemoverEspecialidadeCommandHandler(
            AutenticadorContext context,
            IMediator mediator,
            IHashService hashService)
        {
            _context = context;
            _mediator = mediator;
            _hashService = hashService;
        }

        public async Task<Response<Especialidade>> Handle(RemoverEspecialidadeCommand request, CancellationToken cancellationToken)
        {
            var result = Response<Especialidade>.WithResult(null);
            var existsAlredy = await _context.Especialidades.AnyAsync(u => u.Codigo == request.CodigoEspecialidade);

            if (!existsAlredy)
            {
                result.AddError("Não existe uma especialidade com este nome, utilize outro nome.");
                return result;
            }

            var especialidade = await _context.Especialidades.FirstOrDefaultAsync(u => u.Codigo == request.CodigoEspecialidade);

            _context.Especialidades.Remove(especialidade);
            await _context.SaveChangesAsync();

            return Response<Especialidade>.WithResult(especialidade);
        }


    }
}
