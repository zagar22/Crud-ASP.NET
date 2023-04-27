using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TpCrudAsp.Models;

namespace TpCrudAsp.Controllers
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
            return View();
        }

        public ActionResult VistaParcial()
        {

            var m = new ModelAutos();

            m.img = "~/Content/pic.jpg";
           

            return View(m);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}