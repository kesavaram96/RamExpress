using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RamExpress.Data;
using RamExpress.Models;
using RamExpress.ViewModel;
using System.Diagnostics;

namespace RamExpress.Controllers
{

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
    
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _context= db;
         
            _logger = logger;
        }

        public IActionResult Index()
        {
            var homeView = new HomeModel
            {
                categories = _context.Category.Distinct().ToList(),
                products = _context.Products.ToList(),



            };
            
    
            return View(homeView);
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