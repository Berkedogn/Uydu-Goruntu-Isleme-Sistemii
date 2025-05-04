using System.ComponentModel.DataAnnotations;

namespace SatelliteImageExplorer.Models
{
    public class Beach
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Sahil adı zorunludur.")]
        [StringLength(100, ErrorMessage = "Sahil adı en fazla 100 karakter olabilir.")]
        [Display(Name = "Sahil Adı")]
        public string Name { get; set; }

        [Display(Name = "Şehir")]
        public string? City { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Display(Name = "Uydu Görüntüsü URL")]
        public string? ImageUrl { get; set; }
    }
}
