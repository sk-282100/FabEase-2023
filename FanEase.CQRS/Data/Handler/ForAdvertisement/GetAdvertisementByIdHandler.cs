using ExceptionHandling;
using FanEase.Entity.Models;
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
    public class GetAdvertisementByIdHandler : IRequestHandler<GetAdvertisementByIdQuery, ResponseModel<Advertisement>>
    {
        readonly IAdvertisementRepository _advertisementRepository;

        public GetAdvertisementByIdHandler(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }
        public async Task<ResponseModel<Advertisement>> Handle(GetAdvertisementByIdQuery request, CancellationToken cancellationToken)
        {
            Advertisement advertisement =  await _advertisementRepository.GetAdvertisementById(request.Id);
            return new ResponseModel<Advertisement>() { data = advertisement, message = "data received" };
        }
    }
}
