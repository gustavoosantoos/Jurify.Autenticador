using Microsoft.AspNetCore.Mvc;

namespace Jurify.Autenticador.Web.Areas.Clients.Controllers
{
    [Area("Clients")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}