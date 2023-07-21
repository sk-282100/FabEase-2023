using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models.User
{
    public class LoginVm
    {
        [Required(ErrorMessage = "Enter EmailID/Username")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]

        public string Password { get; set; }
    }
}
