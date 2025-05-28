using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UyduGoruntu.Models;

namespace UyduGoruntu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Ana Sayfa Index Action'ı
        public IActionResult Index()
        {
            return View(); // Ana sayfa görünümünü döndürüyoruz
        }

        // Gizlilik Sayfası (Privacy)
        public IActionResult Privacy()
        {
            return View();
        }

        // Hata Sayfası
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
