using Jurify.Autenticador.Web.UseCases.Services.Concrete;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Jurify.Autenticador.Web.Areas.Commom.Controllers
{
    [EnableCors("Default")]
    public class AccountController : Controller
    {
        public AccountController(SeedDatabase seeder)
        {
            seeder.Seed();
        }

        public IActionResult Login(string returnUrl, string userType = "lawyers")
        {
            return RedirectToAction("Login", "Account", new { area = userType, returnUrl });
        }
    }
}