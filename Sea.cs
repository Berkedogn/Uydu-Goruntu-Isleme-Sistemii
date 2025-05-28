using System.ComponentModel.DataAnnotations;

namespace UyduGoruntu.Models
{
    public class Sea
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Deniz adı zorunludur.")]
        [StringLength(100)]
        public string? Name { get; set; }

        public string? Description { get; set; }

        [Display(Name = "Görsel Dosya Yolu")]
        public string? ImagePath { get; set; }
    }

}
