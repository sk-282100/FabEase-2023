namespace FanEase.UI.Models.Creator
{
    public class CreatorVM
    {
        public string? UserId { get; set; } 
        public string ProfilePhoto { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int VideoCount { get; set; }

        public string Address { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public string ContactNo { get; set; }

        public bool isActive { get; set; } 

        public DateTime CreationDate { get; set; }

        public string UserName { get; set; } 


        public string Password { get; set; }
    }
}
