using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForCampaignAdvertisement;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForCampaignAdvertisement
{
    public class GetAllCampaignAdvertisementsQueryHandler : IRequestHandler<GetAllCampaignAdvertisementsQuery, Response>
    {
        private readonly ICampaignAdvertisementRepository _campaignAdvertisementRepository;
        public GetAllCampaignAdvertisementsQueryHandler(ICampaignAdvertisementRepository campaignAdvertisementRepository)
        {
            _campaignAdvertisementRepository = campaignAdvertisementRepository;
        }
        public async Task<Response> Handle(GetAllCampaignAdvertisementsQuery request, CancellationToken cancellationToken)
        {
            List<Campaign_Advertisement> campaigns = await _campaignAdvertisementRepository.GetAllCampaignAdvertisements();
            Response data = new()
            {
                Result = campaigns,
                Message = "All Campaigns",
                IsSuccess = true,
            };
            return data;
        }
    }
}
