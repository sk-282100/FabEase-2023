using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models.User
{
    public class AddCreatorFormDTO
    {

        [Required(ErrorMessage ="Upload Photo in .jpg, .jpeg or .png format")]
        
        public IFormFile ProfilePhoto { get; set; }

        [MaxLength(12,ErrorMessage ="Maximum 12 Charachters Allowed")]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(12, ErrorMessage = "Maximum 12 Charachters Allowed")]
        [Required]
        public string LastName { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum 12 Charachters Allowed")]
        [Required]
        public string Address { get; set; }

        public string Country { get; set; }

        
        public string City { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
       
        public string ContactNo { get; set; }

        public bool isActive { get; set; }  

        public DateTime CreationDate { get; set; }

    }
}
