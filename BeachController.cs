using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UyduGoruntu.Data;
using UyduGoruntu.Models;
using UyduGoruntu.Data;
using UyduGoruntu.Models;

namespace SatelliteImageExplorer.Controllers
{
    public class BeachesController : Controller
    {
        private readonly AppDbContext _context;

        public BeachesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Beaches
        public async Task<IActionResult> Index()
        {
            return View(await _context.Beaches.ToListAsync());
        }

        // GET: Beaches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var beach = await _context.Beaches.FirstOrDefaultAsync(m => m.Id == id);
            if (beach == null) return NotFound();

            return View(beach);
        }

        // GET: Beaches/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Beaches/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Beach beach)
        {
            if (ModelState.IsValid)
            {
                _context.Add(beach);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(beach);
        }

        // GET: Beaches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var beach = await _context.Beaches.FindAsync(id);
            if (beach == null) return NotFound();

            return View(beach);
        }

        // POST: Beaches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Beach beach)
        {
            if (id != beach.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(beach);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Beaches.Any(e => e.Id == id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(beach);
        }

        // GET: Beaches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var beach = await _context.Beaches.FirstOrDefaultAsync(m => m.Id == id);
            if (beach == null) return NotFound();

            return View(beach);
        }

        // POST: Beaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beach = await _context.Beaches.FindAsync(id);
            _context.Beaches.Remove(beach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
