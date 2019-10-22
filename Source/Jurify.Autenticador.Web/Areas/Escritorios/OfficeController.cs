using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.Infrastructure.SecurityHelpers;
using Jurify.Autenticador.Web.Infrastructure.Shared;
using Jurify.Autenticador.Web.UseCases.Offices.ListOffices;
using Jurify.Autenticador.Web.UseCases.Offices.Modify;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.Areas.Escritorios
{
    [EnableCors("Default")]
    [ApiController]
    [AllowAnonymous]
    [SecurityHeaders]
    [Route("api/advogados/offices")]
    public class OfficeController : BaseController
    {

        private readonly IMediator _mediator;
        private readonly AutenticadorContext _context;

        public OfficeController(IMediator mediator, AutenticadorContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpPut("modificar-escritorio")]
        public async Task<ActionResult> ModificarEscritorio(ModificarEscritorioCommand command)
        {
            return AppResponse(await _mediator.Send(command));
        }

        [HttpGet("dados-escritorio")]
        public async Task<ActionResult> DadosEscritorio(Guid codigoEscritorio)
        {
            return AppResponse(await _mediator.Send(new DadosEscritorioQuery(codigoEscritorio)));
        }

    }
}
