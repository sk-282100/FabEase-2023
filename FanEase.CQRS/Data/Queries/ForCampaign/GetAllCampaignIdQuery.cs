using FanEase.Entity.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Queries.ForCampaign
{
    public class GetAllCampaignIdQuery : IRequest<Response>
    {
        public GetAllCampaignIdQuery(int campaignId)
        {
            this.campaignId = campaignId;
        }

        public int campaignId { get; set; }
    }
}
