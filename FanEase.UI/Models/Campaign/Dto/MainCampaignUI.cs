using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models.Campaign.Dto
{
    public class campadvDetailsUI
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
        //  public IEnumerable<Advertisement> Advertisements { get; set; }
    }
    public class CampaignAdvUI
    {
        public int advertisementId { get; set; }
        public string advertisementTitle { get; set; }
    }

    public class MainCampaignUI
    {
        public campadvDetailsUI campad { get; set; }
        public List<CampaignAdvUI> CampaiAdvclass { get; set; }

    }
}
