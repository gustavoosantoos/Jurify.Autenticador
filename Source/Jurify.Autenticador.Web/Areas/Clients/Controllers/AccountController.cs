using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Jurify.Autenticador.Web.Areas.Clients.Controllers
{
    [Area("Clients")]
    [EnableCors("Default")]
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}