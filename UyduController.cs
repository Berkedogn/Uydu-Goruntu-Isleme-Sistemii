using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace UyduGoruntuWeb.Controllers
{
    public class SatelliteController : Controller
    {
        // Arama formunu gösterir
        public IActionResult Index()
        {
            return View();
        }

        // 🔍 Bölgeye göre arama yapar
        [HttpGet]
        public IActionResult Search(string region)
        {
            if (string.IsNullOrWhiteSpace(region))
            {
                ViewBag.ImagePath = null;
                ViewBag.Info = "Lütfen bir bölge girin.";
                return View("Result");
            }

            string lowerRegion = region.ToLower();

            if (lowerRegion.Contains("akçakoca"))
            {
                ViewBag.ImagePath = "/uploads/akcakoca.jpg"; // wwwroot/uploads içine bu görseli koy!
                ViewBag.Info = "Akçakoca, Düzce iline bağlı Karadeniz kıyısında bir sahil ilçesidir.";
            }
            else
            {
                ViewBag.ImagePath = null;
                ViewBag.Info = "Bu bölge hakkında bilgi bulunamadı.";
            }

            return View("Result");
        }

        // 📷 Kullanıcının yüklediği görseli işler
        [HttpPost]
        public IActionResult UploadImage(IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var uploadsDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
                if (!Directory.Exists(uploadsDir))
                    Directory.CreateDirectory(uploadsDir);

                var filePath = Path.Combine(uploadsDir, image.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(stream);
                }

                ViewBag.ImagePath = "/uploads/" + image.FileName;
                ViewBag.Info = "Yüklediğiniz görsel başarıyla işlendi.";

                // Buraya Python entegrasyonu ileride eklenebilir.

                return View("Result");
            }

            ViewBag.Error = "Bir görsel yükleyin.";
            return View("Index");
        }
    }
}
