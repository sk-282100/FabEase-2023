using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Entity.Models
{
    public class AdvertisementListVM
    {

        public string AdvertisementTitle { get; set; }
        public int AdvertisementId { get; set; }
        public string Image { get; set; }   // Advertisement thumbnailimage

        public string ContentType { get; set; } // Advertisement type=url,video

        public DateTime EndDate { get; set; }   //exp. of Advertisement

        public int AdClicks { get; set; }  // no of Add. clicks


        //field of campaign table

        public string name { get; set; }  //campaign name

        //fields of video table

        public int Views { get; set; } //No. of views

        public bool IsPublished { get; set; } //publish status  true=Go Live , false=draft

        public bool IsActive { get; set; } //active status Active=True , Inactive=False




    }
}
