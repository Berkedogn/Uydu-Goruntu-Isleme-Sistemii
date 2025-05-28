using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UyduGoruntu.Data;
using UyduGoruntu.Models;
using System.Threading.Tasks;
using System.Linq;

namespace UyduGoruntu.Controllers
{
    public class TravelDestinationsController : Controller
    {
        private readonly AppDbContext _context;

        public TravelDestinationsController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TravelDestinations.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var destination = await _context.TravelDestinations.FirstOrDefaultAsync(m => m.Id == id);
            if (destination == null) return NotFound();

            return View(destination);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TravelDestination destination)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destination);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var destination = await _context.TravelDestinations.FindAsync(id);
            if (destination == null) return NotFound();

            return View(destination);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TravelDestination destination)
        {
            if (id != destination.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(destination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destination);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var destination = await _context.TravelDestinations.FirstOrDefaultAsync(m => m.Id == id);
            if (destination == null) return NotFound();

            return View(destination);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destination = await _context.TravelDestinations.FindAsync(id);
            _context.TravelDestinations.Remove(destination);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
