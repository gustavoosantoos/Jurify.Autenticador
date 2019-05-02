using Microsoft.AspNetCore.Mvc;

namespace Jurify.Autenticador.Web.Areas.Commom.Controllers
{
    [Area("Commom")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}