using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models
{
    public class ForgetPasswordVm
    {
        [Required]
        [DataType: DataType.PhoneNumber]
        [MaxLength(10),MinLength(10)]
        
        public string PhoneNumber { get; set; }
    }
}
