using ExceptionHandling;
using FanEase.Middleware.Data.Queries.ForCampaign;
using FanEase.Middleware.Data.Queries.ForVideo;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForCampaign
{
    public class LatestAddedCampaignQueryHandler: IRequestHandler<LatestAddedCampaignQuery,ResponseModel<int>>
    {
        readonly ICampaignRepository _campaignRepository;

        public LatestAddedCampaignQueryHandler(ICampaignRepository campaignRepository)
        {
           _campaignRepository = campaignRepository;
        }
        public async Task<ResponseModel<int>> Handle(LatestAddedCampaignQuery request, CancellationToken cancellationToken)
        {
            int CampaignId = await _campaignRepository.LatestAddedCampaign(request.UserId);
            return new ResponseModel<int> { data = CampaignId, message = "data received" };
        }
    }
}
