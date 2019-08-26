using Jurify.Autenticador.Web.Areas.Lawyers.Models;
using Jurify.Autenticador.Web.Infrastructure.SecurityHelpers;
using Jurify.Autenticador.Web.Infrastructure.Shared;
using Jurify.Autenticador.Web.UseCases.Lawyers.Availability;
using Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial;
using Jurify.Autenticador.Web.UseCases.Lawyers.UserInfoQuery;
using Jurify.Autenticador.Web.UseCases.Offices.Availability;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.Areas.Lawyers.Controllers
{
    [EnableCors("Default")]
    [ApiController]
    [AllowAnonymous]
    [SecurityHeaders]
    [Route("api/lawyers/[controller]")]
    public class AccountController : BaseController
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("OfficeAvailable/{officeName}")]
        public async Task<ActionResult> OfficeAvailable(string officeName)
        {
            var query = new DisponibilidadeEscritorioQuery(officeName);
            return AppResponse(await _mediator.Send(query));
        }

        [HttpGet("UserAvailable/{username}")]
        public async Task<ActionResult> UserAvailable(string username)
        {
            var query = new DisponibilidadeAdvogadoQuery(username);
            return AppResponse(await _mediator.Send(query));
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult> SignUp(SignUpInputModel model)
        {
            var command = new CriarUsuarioInicialCommand(
                model.OfficeName,
                model.Email,
                model.Password,
                model.FirstName,
                model.LastName
            );

            return AppResponse(await _mediator.Send(command));
        }

        [Authorize]
        [HttpGet("UserInfo/{officeId:guid}/{userId:guid}")]
        public async Task<ActionResult> UserInfo(Guid officeId, Guid userId)
        {
            return AppResponse(await _mediator.Send(new DadosUsuarioQuery(officeId, userId)));
        }
    }
}