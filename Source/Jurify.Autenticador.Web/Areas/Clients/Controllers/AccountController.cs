using Microsoft.AspNetCore.Mvc;

namespace Jurify.Autenticador.Web.Areas.Clients.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}