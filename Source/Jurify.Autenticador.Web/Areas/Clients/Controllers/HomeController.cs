using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Jurify.Autenticador.Web.Areas.Clients.Controllers
{
    [Area("Clients")]
    [EnableCors("Default")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}