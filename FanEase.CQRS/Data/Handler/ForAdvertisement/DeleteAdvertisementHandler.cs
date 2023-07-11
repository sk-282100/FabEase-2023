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
    public class DeleteAdvertisementHandler : IRequestHandler<DeleteAdvertisementCommand, ResponseModel<bool>>
    {
        readonly IAdvertisementRepository _advertisementRepository;

        public DeleteAdvertisementHandler(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }
        public async Task<ResponseModel<bool>> Handle(DeleteAdvertisementCommand request, CancellationToken cancellationToken)
        {
            bool status =  await _advertisementRepository.DeleteAdvertisement(request.Id);
            return new ResponseModel<bool> { data = status, message = "Advertisement Deleted" };
        }
    }
}
