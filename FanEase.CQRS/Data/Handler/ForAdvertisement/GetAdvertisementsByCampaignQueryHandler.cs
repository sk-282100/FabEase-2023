using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForAdvertisement;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForAdvertisement
{
    internal class GetAdvertisementsByCampaignQueryHandler : IRequestHandler<GetAdvertisementsByCampaignQuery, ResponseModel<List<AdvertisemenetForTemp>>>
    {

        readonly IAdvertisementRepository _advertisementRepository;

        public GetAdvertisementsByCampaignQueryHandler(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }
        public async Task<ResponseModel<List<AdvertisemenetForTemp>>> Handle(GetAdvertisementsByCampaignQuery request, CancellationToken cancellationToken)
        {
            List<AdvertisemenetForTemp> ads = await _advertisementRepository.GetAdvertisementsByCampaign(request.CampaignId);
            return new ResponseModel<List<AdvertisemenetForTemp>> { data = ads, message = "data received" };
        }
    }
}
