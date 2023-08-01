using System.ComponentModel.DataAnnotations;

namespace FanEase.Entity.Models
{
    public class VideoListVm
    {
        public int VideoId { get; set; }

        // From Advertisement
        public int? AdvertisementId { get; set; }

        public int AdClicks { get; set; } // No. of clicks


        // From Video
        public string? VideoThumbnil { get; set; }
        public string? Title { get; set; }

        public string? VideoType { get; set; } // Live/Pre-Recorded

        public string? Name { get; set; } // Associated Campaign

        public int? Views { get; set; } // No. of Views

        public bool? IsPublished { get; set; } //publish status  true=Go Live , false=draft

        public bool? IsActive { get; set; } //Video Status

        public string? UserId { get; set; }


    }
}
