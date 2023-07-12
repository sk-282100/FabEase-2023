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
    public class CampaignAdvertisementCreateCommandHandler : IRequestHandler<CampaignAdvertisementCreateCommand, Response>
    {
        private readonly ICampaignAdvertisementRepository _campaignAdvertisementRepository;
        public CampaignAdvertisementCreateCommandHandler(ICampaignAdvertisementRepository campaignAdvertisementRepository)
        {
            _campaignAdvertisementRepository = campaignAdvertisementRepository;
        }

        public async Task<Response> Handle(CampaignAdvertisementCreateCommand request, CancellationToken cancellationToken)
        {
            Campaign_Advertisement CampaignAdvertisement = new Campaign_Advertisement
            {
                campaignId = request.campaignId,
                advertisementId = request.advertisementId

            };
            int rowsAffected = await _campaignAdvertisementRepository.CreateCampaignAdvertisement(CampaignAdvertisement);
            Response data = new Response
            {
                Result = rowsAffected > 0 ? CampaignAdvertisement : null,
                Message = rowsAffected > 0 ? "CampaignAdvertisement created successfully" : "Failed to create campaignAdvertisement",
                IsSuccess = rowsAffected > 0
            };

            return data;
           
            

        }
    }
}
