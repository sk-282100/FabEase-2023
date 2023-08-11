using FanEase.Entity.Models;

namespace FanEase.UI.Models.User
{
    public class CreatorDashboardVM
    {
        public int VideoCount { get; set; }

        public int Views { get; set; }

        public List<Video> Videos { get; set; }

        public List<Campaigns> Campaigns { get; set; }
    }
}
