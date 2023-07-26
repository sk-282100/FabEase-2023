using ExceptionHandling;
using FanEase.Entity.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Queries.ForCampaignAdvertisement
{
    public class GetAllCampaignAdvertisementIdQuery : IRequest<ResponseModel<Campaign_Advertisement>>
    {
        public GetAllCampaignAdvertisementIdQuery(int campaignId)
        {
            CampaignId = campaignId;
        }

        public int CampaignId { get; }
    }
}
