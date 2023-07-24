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

    internal class AdvertisementListScreenHandler : IRequestHandler<AdvertisementListScreenQuery, ResponseModel<List<AdvertisementListVM>>>
    {
        readonly IAdvertisementRepository _advertisementRepository;
        public AdvertisementListScreenHandler(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository= advertisementRepository;
        }

        public async Task<ResponseModel<List<AdvertisementListVM>>> Handle(AdvertisementListScreenQuery request, CancellationToken cancellationToken)
        {
            List<AdvertisementListVM> ads = await _advertisementRepository.AdvertisementListScreen();
            return new ResponseModel<List<AdvertisementListVM>> { data = ads, message = "data received" };
        }
    }
}
