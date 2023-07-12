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
    public class CampaignCreateCommandHandler : IRequestHandler<CampaignCreateCommand, Response>
    {
        private readonly ICampaignRepository _campaignRepository;
        public CampaignCreateCommandHandler(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }



        public async Task<Response> Handle(CampaignCreateCommand request, CancellationToken cancellationToken)
        {
            Campaigns campaign = new Campaigns
            {
                name = request.name,
                startDate = request.startDate,
                endDate = request.endDate,
                engagement = request.engagement,
                userId = request.userId
            };

            var rowsAffected = await _campaignRepository.CreateCampaign(campaign);
            Response data = new Response
            {
                Result = rowsAffected > 0 ? campaign : null,
                Message = rowsAffected > 0 ? "Campaign created successfully" : "Failed to create campaign",
                IsSuccess = rowsAffected > 0
            };

            return data;
        }
    }
}