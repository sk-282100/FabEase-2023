using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Commands.ForCampaign;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForCampaign
{
    public class CampaignDeleteCommandHandler : IRequestHandler<CampaignDeleteCommand, ResponseModel<bool>>
    {
        private readonly ICampaignRepository _campaignRepository;
        public CampaignDeleteCommandHandler(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public async Task<ResponseModel<bool>> Handle(CampaignDeleteCommand request, CancellationToken cancellationToken)
        {
            var Campaign = await _campaignRepository.GetCampaignById(request.campaignId);
            if (Campaign == null)
                return default;
            int rowsAffected = await _campaignRepository.DeleteCampaign(request.campaignId);


            var response = new ResponseModel<bool> { data = false, message = "failed to Delete campaign" };
            if (rowsAffected > 0)
            {
                response.data = true;
                response.message = "Campaign Deleted successfully";
            }

            return response;

        }
    }
}
