using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UyduGoruntu.Data;
using UyduGoruntu.Models;

namespace SatelliteImageExplorer.Controllers
{
    public class SeasController : Controller
    {
        private readonly AppDbContext _context;

        public SeasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Seas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Seas.ToListAsync());
        }

        // GET: Seas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var sea = await _context.Seas.FirstOrDefaultAsync(m => m.Id == id);
            if (sea == null) return NotFound();

            return View(sea);
        }

        // GET: Seas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Seas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sea sea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sea);
        }

        // GET: Seas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var sea = await _context.Seas.FindAsync(id);
            if (sea == null) return NotFound();

            return View(sea);
        }

        // POST: Seas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Sea sea)
        {
            if (id != sea.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Seas.Any(e => e.Id == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sea);
        }

        // GET: Seas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var sea = await _context.Seas.FirstOrDefaultAsync(m => m.Id == id);
            if (sea == null) return NotFound();

            return View(sea);
        }

        // POST: Seas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sea = await _context.Seas.FindAsync(id);
            _context.Seas.Remove(sea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
