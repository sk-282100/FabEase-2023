
using FanEase.HelperClasses.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Entity.Models
{
    public class Video
    {
        public int VideoId { get; set; }
        public string VideoImage { get; set; }

        public string VideoThumbnil { get; set; }

        public DateTime GoLiveDateTime { get; set; }    

        public string Title { get; set; }

        public string Description { get; set; }

        public string VideoType { get; set; }  //Live OR Recorded

        public string VideoPlayer { get; set; }

        public string VideoURL { get; set; }

        public string VideoFile { get; set; }

        public double Duration { get; set; }

        public bool IsPublished { get; set; } //publish status

        public bool IsActive { get; set; } //active status

        public int Views { get; set; }

        public int Likes { get; set; } //appriciation

        public int Dislikes { get; set; }  

        public int Skipped { get; set; }

        public int TemplateId { get; set; } //template ref

        public string UserId { get; set; } //user ref

        public int CampaignId { get; set; } //campaign ref


    }
}
