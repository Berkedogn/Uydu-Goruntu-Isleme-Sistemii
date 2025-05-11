using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        // Tüm plajları listele
        public async Task<IActionResult> Index()
        {
            var beaches = await _context.Beaches.ToListAsync();
            return View(beaches);
        }

        // Plaj detaylarını göster
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return BadRequest("ID bilgisi eksik.");

            var beach = await _context.Beaches.FirstOrDefaultAsync(m => m.Id == id);
            if (beach == null) return NotFound("Plaj bulunamadı.");

            return View(beach);
        }

        // Yeni plaj ekleme formu
        public IActionResult Create()
        {
            return View();
        }

        // Yeni plaj ekleme işlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Latitude,Longitude,ImagePath")] Beach beach)
        {
            if (!ModelState.IsValid) return View(beach);

            _context.Add(beach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Plaj düzenleme formu
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest("ID bilgisi eksik.");

            var beach = await _context.Beaches.FindAsync(id);
            if (beach == null) return NotFound("Plaj bulunamadı.");

            return View(beach);
        }

        // Plaj düzenleme işlemi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Latitude,Longitude,ImagePath")] Beach beach)
        {
            if (id != beach.Id) return NotFound("ID uyuşmazlığı.");

            if (!ModelState.IsValid) return View(beach);

            try
            {
                _context.Update(beach);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeachExists(id)) return NotFound("Plaj mevcut değil.");
                throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // Plaj silme onay sayfası
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest("ID bilgisi eksik.");

            var beach = await _context.Beaches.FirstOrDefaultAsync(m => m.Id == id);
            if (beach == null) return NotFound("Plaj bulunamadı.");

            return View(beach);
        }

        // Plaj silme işlemi
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var beach = await _context.Beaches.FindAsync(id);
            if (beach == null) return NotFound();

            _context.Beaches.Remove(beach);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Yardımcı: Plaj mevcut mu kontrolü
        private bool BeachExists(int id)
        {
            return _context.Beaches.Any(e => e.Id == id);
        }
    }
}
