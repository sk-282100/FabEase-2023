using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForCampaign;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForCampaign
{
    public class GetCampaignByDetailsIdQueryHandler : IRequestHandler<GetCampaignByDetailsIdQuery, ResponseModel<Campaigns>>
    {

        private readonly ICampaignRepository _campaignRepository;
        public GetCampaignByDetailsIdQueryHandler(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }
        public async Task<ResponseModel<Campaigns>> Handle(GetCampaignByDetailsIdQuery request, CancellationToken cancellationToken)
        {

            Campaigns campaign = await _campaignRepository.GetCampaignDetailsById(request.campaignId);



            return new ResponseModel<Campaigns> { data = campaign, message = "Campaign Received" };

        }
    }
}
