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
    public class DeleteTemplateDetailsHandler : IRequestHandler<DeleteTemplateDetailsCommand, ResponseModel<bool>>
    {
        readonly ITemplateDetailsRepository _templateDetailsRepository;

        public DeleteTemplateDetailsHandler(ITemplateDetailsRepository templateDetailsRepository)
        {
            _templateDetailsRepository = templateDetailsRepository;
        }

        public async Task<ResponseModel<bool>> Handle(DeleteTemplateDetailsCommand request, CancellationToken cancellationToken)
        {
            bool staus =  await _templateDetailsRepository.DeleteTemplateDetails(request.Id);
            return new ResponseModel<bool> { data = staus, message = "TemplateDetails Deleted" };
        }
    }
}
