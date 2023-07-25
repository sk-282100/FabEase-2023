using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Entity.Models
{
    public class Advertisement
    {
        public int AdvertisementId { get; set; }

        [Required(ErrorMessage ="Enter Advertisement Title")]
        public string AdvertisementTitle { get; set; }

        [Required(ErrorMessage ="date & Time required")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "date & Time required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Enter Content type like Image,video,url,text")]
        public string ContentType { get; set; } //'Image','Video','Text','URL'

        [Required(ErrorMessage = "Enter Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter Advertisement Image")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Select Advertisement placement")]
        public string AvertisementPlacement { get; set; }

        [Required(ErrorMessage = "Enter URL")]
        public string Url { get; set; }

        [Required(ErrorMessage = "Enter Number of clicks")]
        public int AdClicks { get; set; }

        public string? UserId { get; set; }
    }
}
