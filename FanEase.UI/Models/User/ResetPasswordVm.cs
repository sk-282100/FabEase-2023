using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models.User
{
    public class ResetPasswordVm
    {
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Password not matched")]

        public string ConfirmPassword { get; set; }
    }
}
