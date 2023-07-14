using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models.Creator
{
    public class AddCreatorVM
    {
        [MaxLength(6,ErrorMessage ="Enter Valid CeatorId")]
        [MinLength(6,ErrorMessage = "Enter Valid CeatorId")]
        [Required]
        public string UserId { get; set; }
    }
}
