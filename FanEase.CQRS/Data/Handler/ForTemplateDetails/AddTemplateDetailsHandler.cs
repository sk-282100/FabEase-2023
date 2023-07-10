using ExceptionHandling;
using FanEase.Middleware.Data.Commands.ForTemplateDetails;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForTemplateDetails
{
    public class AddTemplateDetailsHandler : IRequestHandler<AddTemplateDetailsCommand, ResponseModel<bool>>
    {
        readonly ITemplateDetailsRepository _templateDetailsRepository;

        public AddTemplateDetailsHandler(ITemplateDetailsRepository templateDetailsRepository)
        {
            _templateDetailsRepository = templateDetailsRepository;
        }
        public async Task<ResponseModel<bool>> Handle(AddTemplateDetailsCommand request, CancellationToken cancellationToken)
        {
            bool status =  await _templateDetailsRepository.AddTemplateDetails(request.TemplateDetail);
            return new ResponseModel<bool>() { data = status, message = "TemplateDetails Added" };
        }
    }
}
