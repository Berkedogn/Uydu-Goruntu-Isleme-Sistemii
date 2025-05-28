using Microsoft.AspNetCore.Mvc;
using UyduGoruntu.Models;

namespace UyduGoruntu.Controllers
{
    public class MountainsController : Controller
    {
        private static List<Mountain> _mountains = new();

        public IActionResult Index()
        {
            return View(_mountains);
        }

        public IActionResult Details(int id)
        {
            var mountain = _mountains.FirstOrDefault(m => m.Id == id);
            if (mountain == null) return NotFound();
            return View(mountain);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Mountain mountain)
        {
            if (ModelState.IsValid)
            {
                mountain.Id = _mountains.Count > 0 ? _mountains.Max(m => m.Id) + 1 : 1;
                _mountains.Add(mountain);
                return RedirectToAction(nameof(Index));
            }
            return View(mountain);
        }

        public IActionResult Edit(int id)
        {
            var mountain = _mountains.FirstOrDefault(m => m.Id == id);
            if (mountain == null) return NotFound();
            return View(mountain);
        }

        [HttpPost]
        public IActionResult Edit(Mountain mountain)
        {
            var existing = _mountains.FirstOrDefault(m => m.Id == mountain.Id);
            if (existing == null) return NotFound();

            if (ModelState.IsValid)
            {
                existing.Name = mountain.Name;
                existing.City = mountain.City;
                existing.Description = mountain.Description;
                existing.ImageUrl = mountain.ImageUrl;
                existing.Height = mountain.Height;
                return RedirectToAction(nameof(Index));
            }
            return View(mountain);
        }

        public IActionResult Delete(int id)
        {
            var mountain = _mountains.FirstOrDefault(m => m.Id == id);
            if (mountain == null) return NotFound();
            return View(mountain);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var mountain = _mountains.FirstOrDefault(m => m.Id == id);
            if (mountain != null) _mountains.Remove(mountain);
            return RedirectToAction(nameof(Index));
        }
    }
}
