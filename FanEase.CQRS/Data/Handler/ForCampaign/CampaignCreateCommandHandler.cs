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
    public class CampaignCreateCommandHandler : IRequestHandler<CampaignCreateCommand, ResponseModel<bool>>
    {
        private readonly ICampaignRepository _campaignRepository;
        public CampaignCreateCommandHandler(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }



        public async Task<ResponseModel<bool>> Handle(CampaignCreateCommand request, CancellationToken cancellationToken)
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
            var response = new ResponseModel<bool> { data = false, message = "failed to create campaign" };
            if (rowsAffected > 0)
            {
                response.data = true;
                response.message = "Campaign created successfully";
            }

            return response;
        }
    }
}
