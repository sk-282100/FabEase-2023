using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models.User
{
    public class VerifyOTPVm
    {
        [Required]
        [MinLength(6)]
        public int OTP { get; set; }
    }
}
