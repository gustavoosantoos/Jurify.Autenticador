using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Jurify.Autenticador.Web.Features.AccountClients
{
    public class AccountClientsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}