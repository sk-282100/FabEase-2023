using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Entity.Models
{
    public class campadvDetails
    {
        public int AdvertisementId { get; set; }

        [Required(ErrorMessage = "Enter Advertisement Title")]
        [MaxLength(20, ErrorMessage = "Title sholuld be only of 50 letters")]
        public string AdvertisementTitle { get; set; }
    }
}
