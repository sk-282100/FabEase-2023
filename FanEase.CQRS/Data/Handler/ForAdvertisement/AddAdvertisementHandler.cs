using ExceptionHandling;
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
    public class AddAdvertisementHandler : IRequestHandler<AddAdvertisementCommand, ResponseModel<bool>>
    {
        readonly IAdvertisementRepository _advertisementRepository;

        public AddAdvertisementHandler(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }
        public async Task<ResponseModel<bool>> Handle(AddAdvertisementCommand request, CancellationToken cancellationToken)
        {
            bool status= await _advertisementRepository.AddAdvertisement(request.Advertisement);
            return new ResponseModel<bool> { data=status, message="Advertisement Added" };
        }
    }
}
