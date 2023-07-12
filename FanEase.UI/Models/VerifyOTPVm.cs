using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models
{
    public class VerifyOTPVm
    {
        [Required]
        [MinLength(6)]
        public int OTP { get; set; }
    }
}
