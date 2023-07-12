using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Entity.Models
{
    public class User
    {
        [Key]
        public string? UserId { get; set; } //it should be first letter of First & LastName and last 4 digits of ph. no
        public string ProfilePhoto { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int VideoCount { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public string ContactNo { get; set; }

        public bool isActive { get; set; } //IsActive 

        public DateTime CreationDate { get; set; }

        public string UserName { get; set; } //email Address


        public string Password { get; set; }
    }
}
