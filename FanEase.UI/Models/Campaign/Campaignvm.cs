using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models
{
    public class Campaignvm
    {

        public string userId { get; set; }
        [Required(ErrorMessage = "Enter Campaign Name")]
        [MaxLength(20, ErrorMessage = "Campaign Name sholuld be only of 50 letters")]
        public string name { get; set; }

        [Required(ErrorMessage = "date & Time required")]
        public DateTime startDate { get; set; }

        [Required(ErrorMessage = "date & Time required")]
        public DateTime endDate { get; set; }
       public int CampaignId { get; set; }

    }
}
