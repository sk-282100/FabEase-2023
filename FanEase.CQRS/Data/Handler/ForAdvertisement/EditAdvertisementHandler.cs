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
    public class EditAdvertisementHandler : IRequestHandler<EditAdvertisementCommand, ResponseModel<bool>>
    {
        readonly IAdvertisementRepository _advertisementRepository;

        public EditAdvertisementHandler(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }
        public async Task<ResponseModel<bool>> Handle(EditAdvertisementCommand request, CancellationToken cancellationToken)
        {
            bool status =  await _advertisementRepository.EditAdvertisement(request.Advertisement);
            return new ResponseModel<bool> { data = status, message = "Advertisement Updated" };
        }
    }
}
