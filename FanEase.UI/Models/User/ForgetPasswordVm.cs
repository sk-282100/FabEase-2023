using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models.User
{
    public class ForgetPasswordVm
    {
        [Required()]
        [DataType(DataType.EmailAddress)]
        
         public string Email { get; set; }
    }
}
