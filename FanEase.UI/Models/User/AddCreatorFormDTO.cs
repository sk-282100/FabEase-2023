using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models.User
{
    public class AddCreatorFormDTO
    {

        [Required(ErrorMessage ="Upload Photo in .jpg, .jpeg or .png format")]
        
        public IFormFile ProfilePhoto { get; set; }

        [MaxLength(50,ErrorMessage ="Maximum 50 Charachters Allowed")]
        [Required(ErrorMessage ="Enter Name")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum 50 Charachters Allowed")]
        [Required(ErrorMessage ="Enter Last Name")]
        public string LastName { get; set; }

        [MaxLength(100, ErrorMessage = "Maximum 100 Charachters Allowed")]
        [Required(ErrorMessage ="Enter Address")]
        public string Address { get; set; }

        [Required(ErrorMessage ="Enter Country")]
        public string Country { get; set; }

        [Required(ErrorMessage ="Enter City")]
        public string City { get; set; }

        [Required(ErrorMessage ="Enter Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage ="Enter Contact Number")]

        [StringLength(10,ErrorMessage ="Enter 10 Digit Contact Number")]
        public string ContactNo { get; set; }

        public bool isActive { get; set; }  

        public DateTime CreationDate { get; set; }

    }
}
