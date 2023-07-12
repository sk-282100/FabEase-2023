using FanEase.Entity.Models;
using FanEase.Middleware.Data.Commands.ForCampaignAdvertisement;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForCampaignAdvertisement
{
    public class UpdateCampaignAdvertisementCommandHandler : IRequestHandler<UpdateCampaignAdvertisementCommand, Response>
    {
        private readonly ICampaignAdvertisementRepository _campaignAdvertisementRepository;
        public UpdateCampaignAdvertisementCommandHandler(ICampaignAdvertisementRepository campaignAdvertisementRepository)
        {
            _campaignAdvertisementRepository = campaignAdvertisementRepository;
        }
        public async Task<Response> Handle(UpdateCampaignAdvertisementCommand request, CancellationToken cancellationToken)
        {
            Campaign_Advertisement CampaignAdvertisement = new Campaign_Advertisement
            {
                Id = request.Id,
                campaignId = request.campaignId,
                advertisementId = request.advertisementId
            };

            var rowsAffected = await _campaignAdvertisementRepository.UpdateCampaignAdvertisement(CampaignAdvertisement);

            Response data = new Response
            {
                Result = rowsAffected > 0 ? CampaignAdvertisement : null,
                Message = rowsAffected > 0 ? "CampaignAdvertisement Updated successfully" : "Failed to create campaign",
                IsSuccess = rowsAffected > 0
            };

            return data;
        }
    }
}
