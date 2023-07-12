using FanEase.Entity.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForCampaign
{
    public class UpdateCampaignCommand : IRequest<Response>
    {
        public int campaignId { get; set; }
        public string name { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int engagement { get; set; }
        public int userId { get; set; }
    }
}
