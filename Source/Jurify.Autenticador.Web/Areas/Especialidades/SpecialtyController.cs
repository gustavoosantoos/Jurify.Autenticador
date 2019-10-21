using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.Infrastructure.SecurityHelpers;
using Jurify.Autenticador.Web.Infrastructure.Shared;
using Jurify.Autenticador.Web.UseCases.Specialties.Create;
using Jurify.Autenticador.Web.UseCases.Specialties.CreateOfficeSpecialty;
using Jurify.Autenticador.Web.UseCases.Specialties.ListSpecialties;
using Jurify.Autenticador.Web.UseCases.Specialties.RemoveOfficeSpecialty;
using Jurify.Autenticador.Web.UseCases.Specialties.RemoveSpecialty;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.Areas.Especialidades
{
    [EnableCors("Default")]
    [ApiController]
    [AllowAnonymous]
    [SecurityHeaders]
    [Route("api/advogados/specialties")]
    public class SpecialtyController : BaseController
    {

        private readonly IMediator _mediator;
        private readonly AutenticadorContext _context;

        [HttpPost("cadastrar-especialidade")]
        public async Task<ActionResult> CadastrarEspecialidade(CriarEspecialidadeCommand command)
        {
            return AppResponse(await _mediator.Send(command));
        }

        [HttpPut("modificar-especialidade")]
        public async Task<ActionResult> ModificarEspecialidade(ModificarEspecialidadeCommand command)
        {
            return AppResponse(await _mediator.Send(command));
        }

        [HttpPost("cadastrar-especialidade-escritorio")]
        public async Task<ActionResult> CadastrarEspecialidadeEScritorio(CriarEspecialidadeEscritorioCommand command)
        {
            return AppResponse(await _mediator.Send(command));
        }

        [HttpDelete("remover-especialidade")]
        public async Task<ActionResult> RemoverEspecialidade(Guid codigoEspecialidade)
        {
            return AppResponse(await _mediator.Send(new RemoverEspecialidadeCommand(codigoEspecialidade)));
        }

        [HttpDelete("remover-especialidade-escritorio")]
        public async Task<ActionResult> RemoverEspecialidadeEscritorio(Guid codigoEspecialidadeEscritorio)
        {
            return AppResponse(await _mediator.Send(new RemoverEspecialidadeEscritorioCommand(codigoEspecialidadeEscritorio)));
        }

        public SpecialtyController(IMediator mediator, AutenticadorContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpGet("listar-especialidades")]
        public async Task<ActionResult> ListarEspecialidades()
        {
            return Ok(_context.Especialidades
               );
        }

        [HttpGet("listar-especialidades-escritorio")]
        public async Task<ActionResult> ListarEspecialidadesEscritorio(Guid codigoEscritorio)
        {
            return Ok(await _mediator.Send(new ListarEspecialidadesEscritorioQuery(codigoEscritorio))
               );
        }
    }
}
