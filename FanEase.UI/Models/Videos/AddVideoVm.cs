namespace FanEase.UI.Models.Videos
{
    public class AddVideoVm
    {
        public string? VideoImage { get; set; }

        public string? VideoThumbnil { get; set; }

        public DateTime GoLiveDateTime { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string? VideoType { get; set; }

        public string VideoPlayer { get; set; }

        public string VideoURL { get; set; }

        public string? VideoFile { get; set; }
    }
}
