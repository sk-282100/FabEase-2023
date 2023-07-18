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
    public class UpdateCampaignAdvertisementCommandHandler : IRequestHandler<UpdateCampaignAdvertisementCommand, ResponseModel<bool>>
    {
        private readonly ICampaignAdvertisementRepository _campaignAdvertisementRepository;
        public UpdateCampaignAdvertisementCommandHandler(ICampaignAdvertisementRepository campaignAdvertisementRepository)
        {
            _campaignAdvertisementRepository = campaignAdvertisementRepository;
        }
        public async Task<ResponseModel<bool>> Handle(UpdateCampaignAdvertisementCommand request, CancellationToken cancellationToken)
        {
            Campaign_Advertisement CampaignAdvertisement = new Campaign_Advertisement
            {
                Id = request.Id,
                campaignId = request.campaignId,
                advertisementId = request.advertisementId
            };

            var rowsAffected = await _campaignAdvertisementRepository.UpdateCampaignAdvertisement(CampaignAdvertisement);

            ResponseModel<bool> data = new ResponseModel<bool>
            {
                data = rowsAffected > 0 ? true : false,
                message = rowsAffected > 0 ? "CampaignAdvertisement Updated successfully" : "Failed to create campaign",
                Succeed = rowsAffected > 0
            };

            return data;
        }
    }
}
