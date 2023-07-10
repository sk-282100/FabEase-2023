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
    public class GetAdvertisementsByUserHandler : IRequestHandler<GetAdvertisementsByUserQuery, ResponseModel<List<Advertisement>>>
    {
        readonly IAdvertisementRepository _advertisementRepository;
        public GetAdvertisementsByUserHandler(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }
        public async Task<ResponseModel<List<Advertisement>>> Handle(GetAdvertisementsByUserQuery request, CancellationToken cancellationToken)
        {
            List<Advertisement> advertisements= await _advertisementRepository.GetAdvertisementsByUser(request.UserId);
            return new ResponseModel<List<Advertisement>> { data=advertisements,message="data received" };
        }
    }
}
