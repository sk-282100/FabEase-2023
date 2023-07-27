using System.ComponentModel.DataAnnotations;

namespace FanEase.UI.Models.Videos
{
    public class EditVideoVM
    {
        public int VideoId { get; set; }
        public string? VideoImage { get; set; }

        public string? VideoThumbnil { get; set; }

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

        public string? VideoURL { get; set; }

        public string? VideoFile { get; set; }

        public double Duration { get; set; }

        public bool IsPublished { get; set; } //publish status

        public bool IsActive { get; set; } //active status

        public int Views { get; set; }

        public int Likes { get; set; } //appriciation

        public int Dislikes { get; set; }

        public int Skipped { get; set; }

        public int? TemplateId { get; set; } //template ref

        public string? UserId { get; set; } //user ref

        public int? CampaignId { get; set; } //campaign ref

        public IFormFile? UploadVideoImage { get; set; }

        public IFormFile? UploadVideo { get; set; }
        public DateTime? NewGoLiveDateTime { get; set; }

    }
}
