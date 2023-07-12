using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models
{
    public class LoginVm
    {
        [Required]
        [DataType:DataType.Email]
        public string EmailId { get; set; }

        [Required]
        [DataType: DataType.Password]
        public string Password { get; set; }
    }
}
