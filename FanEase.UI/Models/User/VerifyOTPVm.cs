using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models.User
{
    public class VerifyOTPVm
    {
        [Required]
        [MinLength(6)]
        public string OTP { get; set; }
    }
}
