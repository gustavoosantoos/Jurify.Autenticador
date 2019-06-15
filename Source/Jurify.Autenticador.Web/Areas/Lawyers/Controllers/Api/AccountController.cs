using Jurify.Autenticador.Web.Infrastructure.Extensions;
using Jurify.Autenticador.Web.Infrastructure.SecurityHelpers;
using Jurify.Autenticador.Web.Infrastructure.Shared;
using Jurify.Autenticador.Web.UseCases.Lawyers.Availability;
using Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial;
using Jurify.Autenticador.Web.UseCases.Offices.Availability;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.Areas.Lawyers.Controllers.Api
{
    [Area("Lawyers")]
    [Route("api/[controller]")]
    [EnableCors("Default")]
    [ApiController]
    [AllowAnonymous]
    [SecurityHeaders]
    public class AccountController : BaseController
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/OfficeAvailable/{officeName}")]
        public async Task<ActionResult> OfficeAvailable(string officeName)
        {
            var query = new CheckOfficeAvailabilityQuery(officeName);
            return AppResponse(await _mediator.Send(query));
        }

        [HttpGet("/UserAvailable/{username}")] 
        public async Task<ActionResult> UserAvailableAsync(string username)
        {
            var query = new CheckLawyerAvailabilityQuery(username);
            return AppResponse(await _mediator.Send(query));
        }

        [HttpPost]
        public async Task<ActionResult> CreateOfficeAsync(CreateInitialLawyerCommand command)
        {
            return AppResponse(await _mediator.Send(command));
        }
    }
}