using ExceptionHandling;
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
    public class GetCampaignAdvertisementByCampaignIdQueryHandler : IRequestHandler<GetAllCampaignAdvertisementIdQuery, ResponseModel<Campaign_Advertisement>>
    {

        private readonly ICampaignAdvertisementRepository _campaignAdvertisementRepository;
        public GetCampaignAdvertisementByCampaignIdQueryHandler(ICampaignAdvertisementRepository campaignAdvertisementRepository)
        {
            _campaignAdvertisementRepository = campaignAdvertisementRepository;
        }
        public async Task<ResponseModel<Campaign_Advertisement>> Handle(GetAllCampaignAdvertisementIdQuery request, CancellationToken cancellationToken)
        {
            Campaign_Advertisement campaign = await _campaignAdvertisementRepository.GetCampaignAdvertisementById(request.CampaignId);
           
            return new ResponseModel<Campaign_Advertisement> { data= campaign , message ="CampaignAdvertisement Found"};

        }
    }
}
