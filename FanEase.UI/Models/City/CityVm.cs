using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models.City
{
    public class CityVm
    {
        public int CityId { get; set; }
        [MaxLength(20, ErrorMessage = "Maximum 20 Charachters Allowed")]
        [Required]
        public string CityName { get; set; }
        [Required(ErrorMessage = "Select State")]
        public int StateId { get; set; }
    }
}
