using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models.Country
{
    public class Country
    {

        public int CountryId { get; set; }
        [Required(ErrorMessage = "Country Name is required.")]
        [MaxLength(15, ErrorMessage = "Country Name cannot exceed 15 characters.")]
        public string CountryName { get; set; }
    }
}
