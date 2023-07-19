using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models.User
{
    public class LoginVm
    {
        [Required]
        [DataType:DataType.Email]
        public string Email { get; set; }

        [Required]
        [DataType: DataType.Password]
        public string Password { get; set; }
    }
}
