using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UyduGoruntu.Data;
using UyduGoruntu.Models;

namespace UyduGoruntu.Controllers
{
    public class CitiesController : Controller
    {
        private readonly AppDbContext _context;

        public CitiesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Cities.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(City city)
        {
            if (ModelState.IsValid)
            {
                _context.Add(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var city = await _context.Cities.FindAsync(id);
            if (city == null) return NotFound();

            return View(city);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, City city)
        {
            if (id != city.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(city);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var city = await _context.Cities.FirstOrDefaultAsync(m => m.Id == id);
            if (city == null) return NotFound();

            return View(city);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var city = await _context.Cities.FindAsync(id);
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var city = await _context.Cities.FirstOrDefaultAsync(m => m.Id == id);
            if (city == null) return NotFound();

            return View(city);
        }
    }
}
