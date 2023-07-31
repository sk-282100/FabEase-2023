

using FanEase.Entity.Models;

namespace FanEase.UI.Models.Creator
{
    public class CreatorDetailsVM
    {
        public CreatorVM Creator { get; set; }
        public List<Advertisement> Advertisements{ get; set; }

        public List<Video> Videos { get; set; }
    }
}
