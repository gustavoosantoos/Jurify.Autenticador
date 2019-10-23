using Jurify.Autenticador.Web.Infrastructure.Database.Context;
using Jurify.Autenticador.Web.Infrastructure.SecurityHelpers;
using Jurify.Autenticador.Web.Infrastructure.Shared;
using Jurify.Autenticador.Web.UseCases.Advogados.ListarEstadosBrasileiros;
using Jurify.Autenticador.Web.UseCases.Lawyers.Availability;
using Jurify.Autenticador.Web.UseCases.Lawyers.CreateInitial;
using Jurify.Autenticador.Web.UseCases.Lawyers.Modify;
using Jurify.Autenticador.Web.UseCases.Lawyers.UserInfoQuery;
using Jurify.Autenticador.Web.UseCases.Offices.Availability;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Jurify.Autenticador.Web.Areas.Lawyers.Controllers
{
    [EnableCors("Default")]
    [ApiController]
    [Authorize]
    [AllowAnonymous]
    [SecurityHeaders]
    [Route("api/advogados/account")]
    public class AccountController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly AutenticadorContext _context;

        public AccountController(IMediator mediator, AutenticadorContext context)
        {
            _mediator = mediator;
            _context = context;
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

        [HttpPost("cadastrar-novo")]
        public async Task<ActionResult> CadastrarNovo(CriarUsuarioNovoCommand command)
        {
            return AppResponse(await _mediator.Send(command));
        }

        [HttpPut("modificar-usuario")]
        public async Task<ActionResult> ModificarUsuario(ModificarUsuarioCommand command)
        {
            return AppResponse(await _mediator.Send(command));
        }

        [HttpDelete("remover")]
        public async Task<ActionResult> Remover(Guid codigoUsuario)
        {
            return AppResponse(await _mediator.Send(new RemoverUsuarioCommand(codigoUsuario)));
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

        [Authorize("admin")]
        [HttpGet("listar-escritorios-usuarios")]
        public async Task<ActionResult> ListarTudo()
        {
            return Ok(_context.Escritorios
                .Include(e => e.Usuarios)
                .Include(e => e.Endereco));
        }

        [Authorize("admin")]
        [HttpGet("listar-usuarios-escritorio")]
        public async Task<ActionResult> ListarUSuariosDoEscritorio(Guid codigoEscritorio)
        {
            return AppResponse(await _mediator.Send(new ListarUsuariosDoEscritorioQuery(codigoEscritorio)));
        }

    }
}