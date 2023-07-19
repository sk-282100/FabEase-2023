namespace FanEase.UI.Models.User
{
    public class AddCreatorFormDTO
    {
       
        public IFormFile ProfilePhoto { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public string ContactNo { get; set; }

        public bool isActive { get; set; }  

        public DateTime CreationDate { get; set; }

    }
}
