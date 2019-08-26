using Jurify.Autenticador.Web.Infrastructure.Shared;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Jurify.Autenticador.Web.Areas.Clients.Controllers
{
    [ApiController]
    [EnableCors("Default")]
    [Route("api/clientes/account")]
    public class AccountController : BaseController
    {

    }
}