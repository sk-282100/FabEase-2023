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
    public class GetAllCampaignIdQueryHandler : IRequestHandler<GetAllCampaignIdQuery, ResponseModel<MainCampaign>>
    {

        private readonly ICampaignRepository _campaignRepository;
        public GetAllCampaignIdQueryHandler(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }
        public async Task<ResponseModel<MainCampaign>> Handle(GetAllCampaignIdQuery request, CancellationToken cancellationToken)
        {

            MainCampaign campaign = await _campaignRepository.GetCampaignById(request.campaignId);


           
            return new ResponseModel<MainCampaign> { data = campaign, message = "Campaign Received" };

        }
    }
}
