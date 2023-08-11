﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Entity.Models
{
    public class campadvDetails
    {
        public string userId { get; set; }
        [Required(ErrorMessage = "Enter Campaign Name")]
        [MaxLength(20, ErrorMessage = "Campaign Name sholuld be only of 50 letters")]
        public string name { get; set; }

        [Required(ErrorMessage = "date & Time required")]
        public DateTime startDate { get; set; }

        [Required(ErrorMessage = "date & Time required")]
        public DateTime endDate { get; set; }
        public int CampaignId { get; set; }
        //  public IEnumerable<Advertisement> Advertisements { get; set; }
    }
    public class CampaignAdv
    {
        public int advertisementId { get; set; }
        public string advertisementTitle { get; set; }
    }

    public class MainCampaign
    {
        public campadvDetails campad { get; set; }
        public List<CampaignAdv> CampaiAdvclass { get; set; }
        
    }
}