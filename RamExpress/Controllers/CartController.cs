using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RamExpress.Data;
using RamExpress.Models;

namespace RamExpress.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cart
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Card.Include(c => c.Product).Include(c => c.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cart/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Card == null)
            {
                return NotFound();
            }

            var card = await _context.Card
                .Include(c => c.Product)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // GET: Cart/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Cart/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ProductId,Quantitive")] Card card)
        {
            if (ModelState.IsValid)
            {
                _context.Add(card);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName", card.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", card.UserId);
            return View(card);
        }

        // GET: Cart/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Card == null)
            {
                return NotFound();
            }

            var card = await _context.Card.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName", card.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", card.UserId);
            return View(card);
        }

        // POST: Cart/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ProductId,Quantitive")] Card card)
        {
            if (id != card.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(card);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardExists(card.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "ProductName", card.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", card.UserId);
            return View(card);
        }

        // GET: Cart/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Card == null)
            {
                return NotFound();
            }

            var card = await _context.Card
                .Include(c => c.Product)
                .Include(c => c.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (card == null)
            {
                return NotFound();
            }

            return View(card);
        }

        // POST: Cart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Card == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Card'  is null.");
            }
            var card = await _context.Card.FindAsync(id);
            if (card != null)
            {
                _context.Card.Remove(card);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardExists(int id)
        {
          return _context.Card.Any(e => e.Id == id);
        }
    }
}
