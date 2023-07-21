using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.UI.Models.Creator
{
    public class LoginDto
    {
        [Required(ErrorMessage ="Enter EmailID/Username")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]

        public string Password { get; set; }
    }
}
