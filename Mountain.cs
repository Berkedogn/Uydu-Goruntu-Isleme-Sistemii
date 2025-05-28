using System.ComponentModel.DataAnnotations;

namespace UyduGoruntu.Models
{
    public class Mountain
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Dağ adı boş bırakılamaz.")]
        [StringLength(100, ErrorMessage = "Dağ adı en fazla 100 karakter olabilir.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Şehir adı boş bırakılamaz.")]
        public string City { get; set; }

        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Display(Name = "Görsel URL")]
        [Required(ErrorMessage = "Bir görsel URL giriniz.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Yükseklik bilgisi zorunludur.")]
        [Range(1, 9000, ErrorMessage = "Yükseklik 1 ile 9000 metre arasında olmalıdır.")]
        public int Height { get; set; } // <-- Eksik olan alan
    }
}
