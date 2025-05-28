using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using UyduGoruntu.Data;
using UyduGoruntu.Models;

namespace UyduGoruntu.Controllers
{
    public class HistoricPlacesController : Controller
    {
        private readonly AppDbContext _context;

        public HistoricPlacesController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.HistoricPlaces.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var historicPlace = await _context.HistoricPlaces.FirstOrDefaultAsync(m => m.Id == id);
            if (historicPlace == null) return NotFound();

            return View(historicPlace);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HistoricPlace historicPlace)
        {
            if (ModelState.IsValid)
            {
                _context.HistoricPlaces.Add(historicPlace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(historicPlace);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var historicPlace = await _context.HistoricPlaces.FindAsync(id);
            if (historicPlace == null) return NotFound();

            return View(historicPlace);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HistoricPlace historicPlace)
        {
            if (id != historicPlace.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(historicPlace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.HistoricPlaces.Any(e => e.Id == id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }
            return View(historicPlace);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var historicPlace = await _context.HistoricPlaces.FirstOrDefaultAsync(m => m.Id == id);
            if (historicPlace == null) return NotFound();

            return View(historicPlace);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var historicPlace = await _context.HistoricPlaces.FindAsync(id);
            if (historicPlace != null)
            {
                _context.HistoricPlaces.Remove(historicPlace);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
