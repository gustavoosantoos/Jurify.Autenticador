using Jurify.Autenticador.Web.Infrastructure.Shared;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Jurify.Autenticador.Web.Areas.Clients.Controllers
{
    [ApiController]
    [EnableCors("Default")]
    [Route("api/clients/[controller]")]
    public class AccountController : BaseController
    {

    }
}