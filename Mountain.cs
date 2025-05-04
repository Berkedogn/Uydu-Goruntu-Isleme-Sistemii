using System.ComponentModel.DataAnnotations;

namespace SatelliteImageExplorer.Models
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
    }
}
