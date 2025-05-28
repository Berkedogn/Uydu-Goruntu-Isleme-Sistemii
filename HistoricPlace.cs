using System.ComponentModel.DataAnnotations;

namespace UyduGoruntu.Models
{
    public class HistoricPlace
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "İsim alanı zorunludur")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur")]
        public string Description { get; set; }

        public string Location { get; set; }

        [Display(Name = "Görsel URL")]
        public string ImageUrl { get; set; }
    }
}
