using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Entity.Models
{
    public class EditCampaignVm
    {
        public int campaignId { get; set; }

        [Required(ErrorMessage = "Enter Campaign Name")]
        [MaxLength(20, ErrorMessage = "Campaign Name sholuld be only of 50 letters")]
        public string name { get; set; }

        [Required(ErrorMessage = "date & Time required")]
        public DateTime startDate { get; set; }

        [Required(ErrorMessage = "date & Time required")]
        public DateTime endDate { get; set; }

        public int engagement { get; set; }

        public string userId { get; set; }
      

    }
}
