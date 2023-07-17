namespace FanEase.UI.Models.Creator
{
    public class CreatorListVM
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int VideoCount { get; set; }
        public string Email { get; set; }

        public int ContactNo { get; set; }

        public DateTime CreationDate { get; set; }

        public bool isActive { get; set; }
    }
}
