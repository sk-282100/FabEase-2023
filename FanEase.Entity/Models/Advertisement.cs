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
        public int? AdvertisementId { get; set; }

        [Required(ErrorMessage ="Enter Advertisement Title")]
        [MaxLength(20 ,ErrorMessage ="Title sholuld be only of 50 letters")]
        public string AdvertisementTitle { get; set; }

        [Required(ErrorMessage ="date & Time required")]
        public DateTime StartDate { get; set; }
        
        
       [Required(ErrorMessage = "date & Time required")]
      
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Select Advertisement type")]
        public string ContentType { get; set; } // In view this fiels is Advertisement type,'Image','Video','Text' OR 'URL'


        [Required(ErrorMessage = "Enter Description")]
        [MaxLength(50, ErrorMessage = "Description should be only of 100 letters")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Enter Advertisement Image")]
        public string? Image { get; set; }

        
        
        [Required(ErrorMessage = "Select Advertisement placement")]
        public string AvertisementPlacement { get; set; }

        
        
       
        public string? Url { get; set; }


        [Required(ErrorMessage = "Enter Number of clicks")]
        public int AdClicks { get; set; }

        public string? UserId { get; set; }
    }
}
