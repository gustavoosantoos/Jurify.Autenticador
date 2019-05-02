using Microsoft.AspNetCore.Mvc;

namespace Jurify.Autenticador.Web.Areas.Commom.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}