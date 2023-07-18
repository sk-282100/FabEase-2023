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
    public class GetAllCampaignAdvertisementsQueryHandler : IRequestHandler<GetAllCampaignAdvertisementsQuery, ResponseModel<List<Campaign_Advertisement>>>
    {
        private readonly ICampaignAdvertisementRepository _campaignAdvertisementRepository;
        public GetAllCampaignAdvertisementsQueryHandler(ICampaignAdvertisementRepository campaignAdvertisementRepository)
        {
            _campaignAdvertisementRepository = campaignAdvertisementRepository;
        }
        public async Task<ResponseModel<List<Campaign_Advertisement>>> Handle(GetAllCampaignAdvertisementsQuery request, CancellationToken cancellationToken)
        {
            List<Campaign_Advertisement> campaigns = await _campaignAdvertisementRepository.GetAllCampaignAdvertisements();
           
            return new ResponseModel<List<Campaign_Advertisement>> { data= campaigns, message="All campaigns"};
        }
    }
}
