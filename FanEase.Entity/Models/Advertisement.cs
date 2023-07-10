using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Entity.Models
{
    public class Advertisement
    {
        public int AdvertisementId { get; set; }

        public string AdvertisementTitle { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string ContentType { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public string AvertisementPlacement { get; set; }

        public string Url { get; set; }

        public int AdClicks { get; set; }

        public string UserId { get; set; }
    }
}
