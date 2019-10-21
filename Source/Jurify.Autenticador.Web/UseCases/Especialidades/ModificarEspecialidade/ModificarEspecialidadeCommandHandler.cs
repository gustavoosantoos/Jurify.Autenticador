using Jurify.Autenticador.Web.Domain.Model.Entities;
using Jurify.Autenticador.Web.Domain.Model.Enums;
using Jurify.Autenticador.Web.Domain.Model.Services.Abstractions;
using Jurify.Autenticador.Web.Domain.Model.ValueObjects;
using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.UseCases.Advogados.CriarUsuarioInicial;
using Jurify.Autenticador.Web.UseCases.Core;
using Jurify.Autenticador.Web.UseCases.Offices.Create;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Especialidade = Jurify.Autenticador.Web.Domain.Model.Entities.Especialidade;

namespace Jurify.Autenticador.Web.UseCases.Specialties.Create
{
    public class ModificarEspecialidadeCommandHandler : IRequestHandler<ModificarEspecialidadeCommand, Response<Especialidade>>
    {
        private readonly AutenticadorContext _context;
        private readonly IMediator _mediator;
        private readonly IHashService _hashService;

        public ModificarEspecialidadeCommandHandler(
            AutenticadorContext context,
            IMediator mediator,
            IHashService hashService)
        {
            _context = context;
            _mediator = mediator;
            _hashService = hashService;
        }

        public async Task<Response<Especialidade>> Handle(ModificarEspecialidadeCommand request, CancellationToken cancellationToken)
        {
            var result = Response<Especialidade>.WithResult(null);
            var especialidade = await _context.Especialidades.FirstOrDefaultAsync(u => u.Codigo == request.CodigoEspecialidade);

            if (especialidade == null)
            {
                result.AddError("Não existe uma especialidade com este mesmo nome, utilize outro nome.");
                return result;
            }

            especialidade.Nome = request.Especialidade.Nome;
            especialidade.Descricao = request.Especialidade.Descricao;

            _context.Especialidades.Update(especialidade);
            await _context.SaveChangesAsync();

            return Response<Especialidade>.WithResult(especialidade);
        }


    }
}
