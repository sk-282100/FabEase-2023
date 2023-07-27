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
    public class GetAllCampaignListScreenByUserIdQueryHandler : IRequestHandler<GetAllCampaignListScreenByUserIdQuery, ResponseModel<List<CampaignListScreenVm>>>
    {
        private readonly ICampaignRepository _campaignRepository;
        public GetAllCampaignListScreenByUserIdQueryHandler(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }
        public async Task<ResponseModel<List<CampaignListScreenVm>>> Handle(GetAllCampaignListScreenByUserIdQuery request, CancellationToken cancellationToken)
        {
            List<CampaignListScreenVm> campaign = await _campaignRepository.CampaignListScreenByUserId(request.userId);



            return new ResponseModel<List<CampaignListScreenVm>> { data = campaign, message = "CampaignList Received" };
        }
    }

}
