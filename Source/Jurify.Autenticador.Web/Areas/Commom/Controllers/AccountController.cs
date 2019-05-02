using Microsoft.AspNetCore.Mvc;

namespace Jurify.Autenticador.Web.Areas.Commom.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string returnUrl, string userType = "lawyers")
        {
            return RedirectToAction("Login", "Account", new { area = userType, returnUrl });
        }
    }
}