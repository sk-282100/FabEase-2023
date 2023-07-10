using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForTemplateDetails;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForTemplateDetails
{
    public class GetAllTemplateDetailsHandler : IRequestHandler<GetAllTemplateDetailsQuery,ResponseModel<List<TemplateDetail>>>
    {
        readonly ITemplateDetailsRepository _templateDetailsRepository;
        public GetAllTemplateDetailsHandler(ITemplateDetailsRepository templateDetailsRepository)
        {
             _templateDetailsRepository = templateDetailsRepository;
        }

        public async Task<ResponseModel<List<TemplateDetail>>> Handle(GetAllTemplateDetailsQuery request, CancellationToken cancellationToken)
        {
            List<TemplateDetail> templetdetails =  await _templateDetailsRepository.GetAllTempletDetails();
            return new ResponseModel<List<TemplateDetail>>() { data= templetdetails, message="data received" };
        }
    }
}
