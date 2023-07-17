using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models.User
{
    public class SetPasswordVm
    {
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Password not matched")]
        public string Password { get; set; }
    }
}
