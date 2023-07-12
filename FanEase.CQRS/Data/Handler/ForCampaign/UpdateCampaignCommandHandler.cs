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
    public class UpdateCampaignCommandHandler : IRequestHandler<UpdateCampaignCommand, Response>
    {
        private readonly ICampaignRepository _campaignRepository;
        public UpdateCampaignCommandHandler(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public async Task<Response> Handle(UpdateCampaignCommand request, CancellationToken cancellationToken)
        {
            Campaigns campaign = new Campaigns
            {
                campaignId = request.campaignId,
                name = request.name,
                startDate = request.startDate,
                endDate = request.endDate,
                engagement = request.engagement,
                userId = request.userId
            };

            var rowsAffected = await _campaignRepository.UpdateCampaign(campaign);
            Response data = new Response
            {
                Result = rowsAffected > 0 ? campaign : null,
                Message = rowsAffected > 0 ? "Campaign deleted successfully" : "Failed to delete campaign",
                IsSuccess = rowsAffected > 0
            };

            return data;
        }
    }
}
