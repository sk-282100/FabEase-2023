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
    public class GetAllAdvertisementHandler : IRequestHandler<GetAllAdvertisementsQuery, ResponseModel<List<Advertisement>>>
    {
        public IAdvertisementRepository _advertisementRepository { get; set; }

        public GetAllAdvertisementHandler(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }
        public async Task<ResponseModel<List<Advertisement>>> Handle(GetAllAdvertisementsQuery request, CancellationToken cancellationToken)
        {
            List<Advertisement> ads =  await _advertisementRepository.GetAllAdvertisements();
            return new ResponseModel<List<Advertisement>> {data= ads, message="data received" };
        }
    }
}
