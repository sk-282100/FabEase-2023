using ExceptionHandling;
using FanEase.Entity.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Queries.ForAdvertisement
{
    public class GetAdvertisementsByCampaignQuery : IRequest<ResponseModel<List<AdvertisemenetForTemp>>>
    {


        public GetAdvertisementsByCampaignQuery(int campaignId)
        {
            CampaignId = campaignId;
        }

        public int CampaignId { get; internal set; }
    }
}
