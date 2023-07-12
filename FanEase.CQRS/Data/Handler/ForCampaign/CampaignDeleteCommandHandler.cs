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
    public class CampaignDeleteCommandHandler : IRequestHandler<CampaignDeleteCommand, Response>
    {
        private readonly ICampaignRepository _campaignRepository;
        public CampaignDeleteCommandHandler(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public async Task<Response> Handle(CampaignDeleteCommand request, CancellationToken cancellationToken)
        {
            var Campaign = await _campaignRepository.GetCampaignById(request.campaignId);
            if (Campaign == null) 
                return default;
            int rowsAffected = await _campaignRepository.DeleteCampaign(request.campaignId);


            Response data = new Response
            {
                Result = rowsAffected > 0 ? request.campaignId : null,
                Message = rowsAffected > 0 ? "Campaign deleted successfully" : "Failed to delete campaign",
                IsSuccess = rowsAffected > 0
            };

            return data;

        }
    }
}
