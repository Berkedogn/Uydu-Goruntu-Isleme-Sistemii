using System.ComponentModel.DataAnnotations;

namespace SatelliteImageExplorer.Models
{
    public class TravelDestination
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Yer adı zorunludur.")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Açıklama zorunludur.")]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public string City { get; set; }
    }
}
