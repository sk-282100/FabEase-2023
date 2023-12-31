﻿using ExceptionHandling;
using FanEase.Entity.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForCampaign
{
    public class UpdateCampaignCommand : IRequest<ResponseModel<bool>>
    {
        public int campaignId { get; set; }
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int engagement { get; set; }
        public string userId { get; set; }
        //[NotMapped]
        //public string Advertisements { get; set; }
    }
}
