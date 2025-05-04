using System.ComponentModel.DataAnnotations;

namespace SatelliteImageExplorer.Models
{
    public class Sea
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Deniz adı zorunludur.")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        public string Description { get; set; }

        public string ImagePath { get; set; }
    }
}
