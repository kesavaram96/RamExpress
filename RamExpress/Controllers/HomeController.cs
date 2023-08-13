using Microsoft.AspNetCore.Mvc;
using RamExpress.Data;
using RamExpress.Models;
using System.Diagnostics;

namespace RamExpress.Controllers
{

    public class HomeController : Controller
    {
        //private readonly ApplicationDbContext _context;
        //public HomeController(ApplicationDbContext db)
        //{
        //    _context = db;
        //}
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
           // var ins=_context.Products.Where(p=>p.)
            _logger = logger;
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