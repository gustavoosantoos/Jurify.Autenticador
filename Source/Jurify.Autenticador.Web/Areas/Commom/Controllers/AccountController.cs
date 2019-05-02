using Microsoft.AspNetCore.Mvc;

namespace Jurify.Autenticador.Web.Areas.Commom.Controllers
{
    [Area("Commom")]
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}