using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SatelliteImageExplorer.Data;
using SatelliteImageExplorer.Models;

namespace SatelliteImageExplorer.Controllers
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(HistoricPlace place)
        {
            if (!ModelState.IsValid)
                return View(place);

            _context.HistoricPlaces.Add(place);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var place = await _context.HistoricPlaces.FindAsync(id);
            if (place == null) return NotFound();
            return View(place);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, HistoricPlace place)
        {
            if (id != place.Id) return NotFound();

            if (!ModelState.IsValid) return View(place);

            _context.HistoricPlaces.Update(place);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var place = await _context.HistoricPlaces.FindAsync(id);
            if (place == null) return NotFound();
            return View(place);
        }

        [HttpPost, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var place = await _context.HistoricPlaces.FindAsync(id);
            if (place == null) return NotFound();

            _context.HistoricPlaces.Remove(place);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var place = await _context.HistoricPlaces.FindAsync(id);
            if (place == null) return NotFound();
            return View(place);
        }
    }
}
