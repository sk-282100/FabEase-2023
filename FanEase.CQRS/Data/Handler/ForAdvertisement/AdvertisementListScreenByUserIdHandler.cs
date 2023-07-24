using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForAdvertisement;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForAdvertisement
{
    internal class AdvertisementListScreenByUserIdHandler : IRequestHandler<AdvertisementListScreenByUserIdQuery, ResponseModel<List<AdvertisementListVM>>>
    {
        public Task<ResponseModel<List<AdvertisementListVM>>> Handle(AdvertisementListScreenByUserIdQuery request, CancellationToken cancellationToken)
        {
            List<AdvertisementListVM> ads = await _advertisementRepository.AdvertisementListScreen();
            return new ResponseModel<List<AdvertisementListVM>> { data = ads, message = "data received" };
        }
    }
}
