using FanEase.Entity.Models;
using FanEase.UI.Models.Advertisements;

namespace FanEase.UI.Models.Campaign
{
    public class CampaignWithAdsDTO
    {
        public Campaignvm Campaign { get; set; }

        public List<SelectAdvertisement> Advertisements { get; set; }

        public int CampaignId { get; set; }

    }
}
