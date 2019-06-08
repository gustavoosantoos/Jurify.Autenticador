using Jurify.Autenticador.Web.Infrastructure.SecurityHelpers;
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
        [HttpGet("/OfficeAvailable/{officeName}")]
        public ActionResult OfficeAvailable(string officeName)
        {
            return Ok();
        }

        [HttpGet("/UserAvailable/{username}")] 
        public ActionResult UserAvailable(string username)
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult CreateOffice(string officeName, string username, string plainPassword)
        {
            return Ok();
        }
    }
}