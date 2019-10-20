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
    public class CriarEspecialidadeCommandHandler : IRequestHandler<CriarEspecialidadeCommand, Response<Especialidade>>
    {
        private readonly AutenticadorContext _context;
        private readonly IMediator _mediator;
        private readonly IHashService _hashService;

        public CriarEspecialidadeCommandHandler(
            AutenticadorContext context,
            IMediator mediator,
            IHashService hashService)
        {
            _context = context;
            _mediator = mediator;
            _hashService = hashService;
        }

        public async Task<Response<Especialidade>> Handle(CriarEspecialidadeCommand request, CancellationToken cancellationToken)
        {
            var result = Response<Especialidade>.WithResult(null);
            var existsAlredy = await _context.Especialidades.AnyAsync(u => u.Nome == request.Especialidade.Nome);
            
            if (existsAlredy)
            {
                result.AddError("Já existe uma especialidade com o mesmo nome, utilize outro nome.");
                return result;
            }

            var especialidade = new Especialidade(request.Especialidade.Nome,request.Especialidade.Descricao);

            await _context.Especialidades.AddAsync(especialidade);
            await _context.SaveChangesAsync();

            return Response<Especialidade>.WithResult(especialidade);
        }


    }
}
