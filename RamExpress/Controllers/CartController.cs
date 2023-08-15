using Microsoft.AspNetCore.Mvc;
using RamExpress.Data;

namespace RamExpress.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        

        public CartController(ApplicationDbContext db)
        {
            _context = db;

           
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(int Id) 
        {
            var product = _context.Products.FirstOrDefault(m => m.Id == Id);
            if (product==null)
            {
                return NotFound();
            }

            _context.Card.Add(new Models.Card{ ProductId=Id, UserId=1});
            _context.SaveChanges();
            
            return RedirectToAction("Home","Index");
        }
    }
}
