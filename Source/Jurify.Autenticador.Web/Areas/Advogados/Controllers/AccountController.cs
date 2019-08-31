using Jurify.Autenticador.Web.Infrastructure.SecurityHelpers;
using Jurify.Autenticador.Web.Infrastructure.Shared;
using Jurify.Autenticador.Web.UseCases.Advogados.ListarEstadosBrasileiros;
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
    [Route("api/advogados/account")]
    public class AccountController : BaseController
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("disponibilidade-escritorio/{nomeFantasia}")]
        public async Task<ActionResult> DisponibilidadeEscritorio(string nomeFantasia)
        {
            var query = new DisponibilidadeEscritorioQuery(nomeFantasia);
            return AppResponse(await _mediator.Send(query));
        }

        [HttpGet("disponibilidade-usuario/{username}")]
        public async Task<ActionResult> DisponibilidadeUsuario(string username)
        {
            var query = new DisponibilidadeAdvogadoQuery(username);
            return AppResponse(await _mediator.Send(query));
        }

        [HttpPost("cadastrar")]
        public async Task<ActionResult> Cadastrar(CriarUsuarioInicialCommand command)
        {
            return AppResponse(await _mediator.Send(command));
        }

        [Authorize]
        [HttpGet("dados-usuario/{codigoEscritorio:guid}/{codigoUsuario:guid}")]
        public async Task<ActionResult> UserInfo(Guid codigoEscritorio, Guid codigoUsuario)
        {
            return AppResponse(await _mediator.Send(new DadosUsuarioQuery(codigoEscritorio, codigoUsuario)));
        }

        [HttpGet("estados-brasileiros")]
        public async Task<ActionResult> ListarEstados()
        {
            return AppResponse(await _mediator.Send(new ListarEstadosBrasileirosQuery()));
        }
    }
}