using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SatelliteImageExplorer.Data;
using SatelliteImageExplorer.Models;

namespace SatelliteImageExplorer.Controllers
{
    public class MountainsController : Controller
    {
        private readonly AppDbContext _context;

        public MountainsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Mountains.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Mountain mountain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mountain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mountain);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var mountain = await _context.Mountains.FindAsync(id);
            if (mountain == null) return NotFound();

            return View(mountain);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Mountain mountain)
        {
            if (id != mountain.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(mountain);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mountain);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var mountain = await _context.Mountains
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mountain == null) return NotFound();

            return View(mountain);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mountain = await _context.Mountains.FindAsync(id);
            _context.Mountains.Remove(mountain);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var mountain = await _context.Mountains
                .FirstOrDefaultAsync(m => m.Id == id);

            if (mountain == null) return NotFound();

            return View(mountain);
        }
    }
}
