using ExceptionHandling;
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
    public class CampaignAdvertisementCreateCommandHandler : IRequestHandler<CampaignAdvertisementCreateCommand, ResponseModel<bool>>
    {
        private readonly ICampaignAdvertisementRepository _campaignAdvertisementRepository;
        public CampaignAdvertisementCreateCommandHandler(ICampaignAdvertisementRepository campaignAdvertisementRepository)
        {
            _campaignAdvertisementRepository = campaignAdvertisementRepository;
        }

        public async Task<ResponseModel<bool>> Handle(CampaignAdvertisementCreateCommand request, CancellationToken cancellationToken)
        {
            Campaign_Advertisement CampaignAdvertisement = new Campaign_Advertisement
            {
                campaignId = request.campaignId,
                advertisementId = request.advertisementId

            };
            int rowsAffected = await _campaignAdvertisementRepository.CreateCampaignAdvertisement(CampaignAdvertisement);
            var response = new ResponseModel<bool> { data = false, message = "failed to create campaignAdvertisement" };
            if (rowsAffected > 0)
            {
                response.data = true;
                response.message = "Campaign created successfully";
            }

            return response;




        }
    }
}
