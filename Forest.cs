// Models/Forest.cs
using System.ComponentModel.DataAnnotations;

namespace SatelliteImageExplorer.Models
{
    public class Forest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Orman adı zorunludur.")]
        [StringLength(100, ErrorMessage = "En fazla 100 karakter olabilir.")]
        [Display(Name = "Orman Adı")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Url(ErrorMessage = "Geçerli bir URL girin.")]
        [Display(Name = "Resim URL")]
        public string ImagePath { get; set; }

        [Required(ErrorMessage = "Şehir bilgisi zorunludur.")]
        [Display(Name = "Şehir")]
        public string City { get; set; }
    }
}
