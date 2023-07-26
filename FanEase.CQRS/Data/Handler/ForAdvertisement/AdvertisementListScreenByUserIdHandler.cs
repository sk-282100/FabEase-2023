using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForAdvertisement;
using FanEase.Repository.Interfaces;
using FanEase_CQRS.Controllers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForAdvertisement
{
    public class AdvertisementListScreenByUserIdHandler : IRequestHandler<AdvertisementListScreenByUserIdQuery, ResponseModel<List<AdvertisementListVM>>>
    {
      
            readonly IAdvertisementRepository _advertisementRepository;

            public AdvertisementListScreenByUserIdHandler(IAdvertisementRepository advertisementRepository)
            {
                _advertisementRepository = advertisementRepository;
            }
            public async Task<ResponseModel<List<AdvertisementListVM>>> Handle(AdvertisementListScreenByUserIdQuery request, CancellationToken cancellationToken)
        {
            List<AdvertisementListVM> ads = await _advertisementRepository.AdvertisementListScreenByUserId(request.UserId);
            return new ResponseModel<List<AdvertisementListVM>> { data = ads, message = "data received" };
        }
    }
}
