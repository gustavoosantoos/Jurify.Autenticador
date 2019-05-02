using Microsoft.AspNetCore.Mvc;

namespace Jurify.Autenticador.Web.Areas.Lawyers.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}