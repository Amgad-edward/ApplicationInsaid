using ApplicationInsaid.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheModels.Models;
using TheModels.InterfaceUnitWork;
using Microsoft.AspNetCore.Session;


namespace ApplicationInsaid.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUntiWorkWebSaite db;

        public HomeController(IUntiWorkWebSaite DB)
        {
            this.db = DB;
        }

        public IActionResult Index()
        {
          
            return View();
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