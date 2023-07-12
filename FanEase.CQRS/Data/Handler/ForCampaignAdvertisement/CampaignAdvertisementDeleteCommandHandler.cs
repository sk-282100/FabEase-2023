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
    public class CampaignAdvertisementDeleteCommandHandler : IRequestHandler<CampaignAdvertisementDeleteCommand, Response>
    {
        private readonly ICampaignAdvertisementRepository _campaignAdvertisementRepository;
        public CampaignAdvertisementDeleteCommandHandler(ICampaignAdvertisementRepository campaignAdvertisementRepository)
        {
            _campaignAdvertisementRepository = campaignAdvertisementRepository;
        }
        public async Task<Response> Handle(CampaignAdvertisementDeleteCommand request, CancellationToken cancellationToken)
        {
            var CampaignAdvertisement = await _campaignAdvertisementRepository.DeleteCampaignAdvertisement(request.Id);
            if (CampaignAdvertisement == null) return default;

            int rowsaffected = await _campaignAdvertisementRepository.DeleteCampaignAdvertisement(request.Id);
            if (rowsaffected < 0)
            {
                return new Response() { IsSuccess = false, Result =request.Id, Message = "Failed to delete campaign" };
            }
            return new Response() { IsSuccess = true, Result = request.Id, Message = "CampaignAdvertisement deleted successfully" };
        }
    }
}
