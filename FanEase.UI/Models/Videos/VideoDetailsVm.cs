using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models.Videos
{
    public class VideoDetailsVm
    {
        public string? VideoImage { get; set; }

        public string? VideoThumbnil { get; set; }

        public DateTime GoLiveDateTime { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string? VideoType { get; set; }

        public string VideoPlayer { get; set; }

        public string? VideoURL { get; set; }

        public string? VideoFile { get; set; }

        public string UserId { get; set; }

        public bool IsPublished { get; set; } = false;//publish status

        public bool IsActive { get; set; } = false;
    }
}
