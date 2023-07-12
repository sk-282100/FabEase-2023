using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models
{
    public class ResetPasswordVm
    {
        [DataType: DataType.Password]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Password not matched")]

        public string ConfirmPassword { get; set; }
    }
}
