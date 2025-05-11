using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SatelliteImageExplorer.Data;
using SatelliteImageExplorer.Models;

namespace SatelliteImageExplorer.Controllers
{
    public class ForestsController : Controller
    {
        private readonly AppDbContext _context;

        public ForestsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Forests
        public async Task<IActionResult> Index()
        {
            var forests = await _context.Forests.ToListAsync();
            return View(forests);
        }

        // GET: Forests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var forest = await _context.Forests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forest == null) return NotFound();

            return View(forest);
        }

        // GET: Forests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Forests/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,ImagePath,City")] Forest forest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(forest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(forest);
        }

        // GET: Forests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var forest = await _context.Forests.FindAsync(id);
            if (forest == null) return NotFound();
            return View(forest);
        }

        // POST: Forests/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ImagePath,City")] Forest forest)
        {
            if (id != forest.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(forest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ForestExists(forest.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(forest);
        }

        // GET: Forests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var forest = await _context.Forests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (forest == null) return NotFound();

            return View(forest);
        }

        // POST: Forests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var forest = await _context.Forests.FindAsync(id);
            _context.Forests.Remove(forest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ForestExists(int id)
        {
            return _context.Forests.Any(e => e.Id == id);
        }
    }
}
