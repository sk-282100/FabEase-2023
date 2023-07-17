using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models.User
{
    public class ForgetPasswordVm
    {
        [Required]
        [DataType: DataType.Email]
        
         public string Email { get; set; }
    }
}
