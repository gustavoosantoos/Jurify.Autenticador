using Jurify.Autenticador.Web.Infrastructure.Shared;
using Jurify.Autenticador.Web.UseCases.Clientes.ListarEscritorios;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.Areas.Clientes.Controllers
{
    [ApiController]
    [EnableCors("Default")]
    [Route("api/clientes/offices")]
    public class OfficesController : BaseController
    {
        private readonly IMediator _mediator;

        public OfficesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return AppResponse(await _mediator.Send(new ListarEscritoriosQuery()));
        }
    }
}