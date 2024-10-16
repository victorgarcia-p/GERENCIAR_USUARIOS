using GERENCIAR_USUARIOS.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GERENCIAR_USUARIOS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //if (!User.Identity.IsAuthenticated)
            //    return RedirectToAction("Index", "Login");

            return View();
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
