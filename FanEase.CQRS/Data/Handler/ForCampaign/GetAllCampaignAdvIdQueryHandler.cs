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
    //public class GetAllCampaignAdvIdQueryHandler : IRequestHandler<GetAllCampaignAdvIdQuery, ResponseModel<EditCampaignVm>>
    //{
    //    private readonly ICampaignRepository _campaignRepository;
    //    public GetAllCampaignAdvIdQueryHandler(ICampaignRepository campaignRepository)
    //    {
    //        _campaignRepository = campaignRepository;
    //    }
    //    public async Task<ResponseModel<EditCampaignVm>> Handle(GetAllCampaignAdvIdQuery request, CancellationToken cancellationToken)
    //    {
    //        EditCampaignVm campaign = await _campaignRepository.EditCampaignAd(request.campaignId);



    //        return new ResponseModel<EditCampaignVm> { Succeed=true, data = campaign, message = "CampaignAdv Received" };
    //    }
    //}
}
