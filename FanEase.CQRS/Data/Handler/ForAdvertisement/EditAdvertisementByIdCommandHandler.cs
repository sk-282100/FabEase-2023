//using ExceptionHandling;
//using FanEase.Middleware.Data.Commands.ForAdvertisement;
//using FanEase.Repository.Interfaces;
//using FanEase_CQRS.Controllers;
//using MediatR;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FanEase.Middleware.Data.Handler.ForAdvertisement
//{
//    public class EditAdvertisementByIdCommandHandler:IRequestHandler<EditAdvertisementByIdCommand, ResponseModel<bool>>
//    {
//        readonly IAdvertisementRepository _advertisementRepository;
//        public EditAdvertisementByIdCommandHandler(IAdvertisementRepository advertisementRepository)
//        {
//            _advertisementRepository=advertisementRepository;
//        }

//        //public async Task<ResponseModel<bool>> Handle(EditAdvertisementByIdCommand request, CancellationToken cancellationToken)
//        //{
//        //    bool status = await _advertisementRepository.EditAdvertisement(request);
//        //    return new ResponseModel<bool> { data = status, message = "Advertisement Updated" };
//        //}
//    }
//}
