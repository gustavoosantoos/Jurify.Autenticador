using Jurify.Autenticador.Web.Infrastructure.SecurityHelpers;
using Jurify.Autenticador.Web.UseCases.Lawyers.Availability;
using Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial;
using Jurify.Autenticador.Web.UseCases.Offices.Availability;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Jurify.Autenticador.Web.Areas.Lawyers.Controllers.Api
{
    [Area("Lawyers")]
    [Route("api/[controller]")]
    [EnableCors("Default")]
    [ApiController]
    [AllowAnonymous]
    [SecurityHeaders]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("/OfficeAvailable/{officeName}")]
        public ActionResult OfficeAvailable(string officeName)
        {
            var query = new CheckOfficeAvailabilityQuery(officeName);
            var response = _mediator.Send(query);
            return Ok();
        }

        [HttpGet("/UserAvailable/{username}")] 
        public ActionResult UserAvailable(string username)
        {
            var query = new CheckLawyerAvailabilityQuery(username);
            var response = _mediator.Send(query);
            return Ok();
        }

        [HttpPost]
        public ActionResult CreateOffice(CreateInitialLawyerCommand command)
        {
            var response = _mediator.Send(command);
            return Ok();
        }
    }
}