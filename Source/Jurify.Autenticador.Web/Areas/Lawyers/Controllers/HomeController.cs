using Microsoft.AspNetCore.Mvc;

namespace Jurify.Autenticador.Web.Areas.Lawyers.Controllers
{
    [Area("Lawyers")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}