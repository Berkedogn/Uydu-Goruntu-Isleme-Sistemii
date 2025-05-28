using System.ComponentModel.DataAnnotations;

namespace UyduGoruntu.Models
{
    public class Beach
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Plaj adı zorunludur.")]
        [StringLength(100)]
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        public string? Description { get; set; }

        [Display(Name = "Görsel URL")]
        public string? ImageUrl { get; set; }
    }
}
