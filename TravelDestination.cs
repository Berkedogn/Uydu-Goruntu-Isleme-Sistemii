using System.ComponentModel.DataAnnotations;

namespace UyduGoruntu.Models
{
    public class TravelDestination
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık boş bırakılamaz.")]
        [StringLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir.")]
        public string Title { get; set; }

        [Display(Name = "Açıklama")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Konum bilgisi girilmelidir.")]
        public string Location { get; set; }

        [Display(Name = "Görsel URL")]
        [Required(ErrorMessage = "Bir görsel URL giriniz.")]
        public string ImageUrl { get; set; }
    }
}
