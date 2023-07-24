using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models.Creator
{
    public class EditCreatorVM
    {
        public string? UserId { get; set; }

        public string ProfilePhoto { get; set; }
        
        
        public IFormFile? UpdatePhoto { get; set; }


        [MaxLength(50, ErrorMessage = "Maximum 50 Charachters Allowed")]
        [Required(ErrorMessage = "Enter Name")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum 50 Charachters Allowed")]
        [Required(ErrorMessage = "Enter Last Name")]
        public string LastName { get; set; }

        [MaxLength(100, ErrorMessage = "Maximum 100 Charachters Allowed")]
        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Enter Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Enter City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Contact Number")]

        public string ContactNo { get; set; }

        public bool isActive { get; set; }

        public DateTime CreationDate { get; set; }

        public string UserName { get; set; }


        public string Password { get; set; }

        public int VideoCount { get; set; }
    }
}
