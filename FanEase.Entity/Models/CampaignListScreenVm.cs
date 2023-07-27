using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Entity.Models
{
    public class CampaignListScreenVm
    {
        public int campaignId { get; set; }
        public string videoThumbnil { get; set; }  //thumbnil
        public string name { get; set; }  //campaignTitle
        public bool isPublished { get; set; }  //publish status
        public bool isActive { get; set; }  // video status

        //  public int AdvertisementCount { get; set; }
        public int views { get; set; }
        public int adClicks { get; set; }
    }
}
