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
    public class GetAllCampaignAdvertisementIdQueryHandler : IRequestHandler<GetAllCampaignAdvertisementIdQuery, Response>
    {

        private readonly ICampaignAdvertisementRepository _campaignAdvertisementRepository;
        public GetAllCampaignAdvertisementIdQueryHandler(ICampaignAdvertisementRepository campaignAdvertisementRepository)
        {
            _campaignAdvertisementRepository = campaignAdvertisementRepository;
        }
        public async Task<Response> Handle(GetAllCampaignAdvertisementIdQuery request, CancellationToken cancellationToken)
        {
            Campaign_Advertisement campaign = await _campaignAdvertisementRepository.GetCampaignAdvertisementById(request.Id);
            Response data = new Response
            {
                Result = campaign,
                Message = "CampaignAdvertisement found",
                IsSuccess = true
            };
            return data;
            
        }
    }
}
