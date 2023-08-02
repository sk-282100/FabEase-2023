using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Entity.Models
{
    public class AdminDashboardDTO
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
