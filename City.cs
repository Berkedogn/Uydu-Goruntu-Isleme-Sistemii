using System.ComponentModel.DataAnnotations;

namespace UyduGoruntu.Models
{
    public class City
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Şehir adı zorunludur.")]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Nüfus")]
        public int Population { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Display(Name = "Görsel URL")]
        public string? ImageUrl { get; set; }
    }
}
