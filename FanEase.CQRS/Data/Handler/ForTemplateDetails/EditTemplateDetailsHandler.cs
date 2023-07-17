using ExceptionHandling;
using FanEase.Middleware.Data.Commands.ForTemplateDetails;
using FanEase.Repository.Interfaces;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForTemplateDetails
{
    public class EditTemplateDetailsHandler : IRequestHandler<EditTemplateDetailsCommand,ResponseModel<bool>>
    {
        readonly ITemplateDetailsRepository _templateDetailsRepository;

        public EditTemplateDetailsHandler(ITemplateDetailsRepository templateDetailsRepository)
        {
            _templateDetailsRepository = templateDetailsRepository;
        }

        public async Task<ResponseModel<bool>> Handle(EditTemplateDetailsCommand request, CancellationToken cancellationToken)
        {
            bool status =  await _templateDetailsRepository.EditTemplateDetails(request.TemplateDetail);
            return new ResponseModel<bool> { data=status, message="TemplateDetails Updated" };
        }
    }
}
