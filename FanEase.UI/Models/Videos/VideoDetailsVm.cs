using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models.Videos
{
    public class VideoDetailsVm
    {
        public string? PlayVideo { get; set; }

        public string? VideoThumbnil { get; set; }
        public string? VideoImage { get; set; }

        public DateTime GoLiveDateTime { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string? VideoType { get; set; }

        public string VideoPlayer { get; set; }

        public string? VideoURL { get; set; }

        public string? VideoFile { get; set; }

        public string UserId { get; set; }

        public int Views { get; set; }

        public int Likes { get; set; }

        public double Duration { get; set; }
    }
}
