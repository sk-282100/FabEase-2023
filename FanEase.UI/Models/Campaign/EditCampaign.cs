using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models.Campaign
{
    public class EditCampaign
    {
        public int campaignId { get; set; }

        [Required(ErrorMessage = "Enter Campaign Name")]
        [MaxLength(20, ErrorMessage = "Campaign Name sholuld be only of 50 letters")]
        public string name { get; set; }

        [Required(ErrorMessage = "date & Time required")]
        public DateTime startDate { get; set; }

        [Required(ErrorMessage = "date & Time required")]
        public DateTime endDate { get; set; }

        public int engagement { get; set; }
        public string userId { get; set; }

        //[NotMapped]
        //public string Advertisements { get; set; }
    }
}
