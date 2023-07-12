using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models
{
    public class ForgetPasswordVm
    {
        [Required]
        [DataType: DataType.Email]
        public string EmailId { get; set; }
    }
}
