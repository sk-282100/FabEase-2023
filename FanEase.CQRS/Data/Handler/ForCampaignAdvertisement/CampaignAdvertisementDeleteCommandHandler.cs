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
    public class CampaignAdvertisementDeleteCommandHandler : IRequestHandler<CampaignAdvertisementDeleteCommand, ResponseModel<bool>>
    {
        private readonly ICampaignAdvertisementRepository _campaignAdvertisementRepository;
        public CampaignAdvertisementDeleteCommandHandler(ICampaignAdvertisementRepository campaignAdvertisementRepository)
        {
            _campaignAdvertisementRepository = campaignAdvertisementRepository;
        }
        public async Task<ResponseModel<bool>> Handle(CampaignAdvertisementDeleteCommand request, CancellationToken cancellationToken)
        {
            var CampaignAdvertisement = await _campaignAdvertisementRepository.DeleteCampaignAdvertisement(request.Id);
            if (CampaignAdvertisement == null) return default;

            int rowsaffected = await _campaignAdvertisementRepository.DeleteCampaignAdvertisement(request.Id);
            var response = new ResponseModel<bool> { data = false, message = "failed to Delete campaign" };
            if (rowsaffected > 0)
            {
                response.data = true;
                response.message = "Campaign Deleted successfully";
            }

            return response;
        }
    }
}
