using FanEase.Entity.Models;

namespace FanEase.UI.Models.User
{
    public class AdminDashboardVM
    {
        public int CreatorCount { get; set; }
        public int AdvertisementCount { get; set; }

        public int VideoCount { get; set; }

        public int AdvertisementClicks { get; set; }

        public int Views { get; set; }

        public List<Video> Videos { get; set; }

        public List<Campaigns> Campaigns { get; set; }
    }
}
