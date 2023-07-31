using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models.State
{
    public class StateVm
    {
        public int StateId { get; set; }
        [MaxLength(20, ErrorMessage = "Maximum 20 Charachters Allowed")]
        [Required]
        public string StateName { get; set; }
        [Required(ErrorMessage = "Select CountryId")]
        public int CountryId { get; set; }
    }
}
