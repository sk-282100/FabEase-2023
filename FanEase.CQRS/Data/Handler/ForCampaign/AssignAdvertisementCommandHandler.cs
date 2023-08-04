using ExceptionHandling;
using FanEase.Middleware.Data.Commands.ForCampaign;
using FanEase.Middleware.Data.Commands.ForVideo;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForCampaign
{
    public class AssignAdvertisementCommandHandler : IRequestHandler<AssignAdvertisementCommand, ResponseModel<bool>>
    {


        readonly ICampaignRepository _campaignRepository;

        public AssignAdvertisementCommandHandler(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public async Task<ResponseModel<bool>> Handle(AssignAdvertisementCommand request, CancellationToken cancellationToken)
        {
            bool status = await _campaignRepository.AssignCampaign(request.CampaignId, request.AdvertisementId);
            return new ResponseModel<bool> { data = status, message = "campaign Added" };
        }


    }
}