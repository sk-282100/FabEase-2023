
using System.ComponentModel.DataAnnotations;


namespace FanEase.UI.Models.Videos
{
    public class AddVideoVm
    {
        public int VideoId { get; set; }
        public IFormFile UploadVideoImage { get; set; }

        public string VideoImage { get; set; }

        public string? VideoThumbnil { get; set; }

        [Required(ErrorMessage = "Select Date and Time")]
        public DateTime GoLiveDateTime { get; set; }

        [MaxLength(25, ErrorMessage = "Maximum 25 Charachters Allowed")]
        [Required]
        public string Title { get; set; }

        [MaxLength(100, ErrorMessage = "Maximum 100 Charachters Allowed")]
        [Required]
        public string Description { get; set; }

        [Required(ErrorMessage = "Select Video Type")]
        public string? VideoType { get; set; }

        [Required(ErrorMessage = "Select Video Player")]
        public string VideoPlayer { get; set; }

        [Required(ErrorMessage = "Enter Video URL")]
        public string? VideoURL { get; set; }

        [Required(ErrorMessage = "Enter Video File")]
        public string? VideoFile { get; set; }

        public IFormFile UploadVideo { get; set; }
        public string UserId { get; set; }

        public bool IsPublished { get; set; } = false;//publish status

        public bool IsActive { get; set; } = false;
    }
}
