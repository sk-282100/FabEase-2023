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
    public class GetTemplateDetailsByIdHandler : IRequestHandler<GetTemplateDetailsByIdQuery, ResponseModel<TemplateDetail>>
    {
        readonly ITemplateDetailsRepository _templateDetailsRepository;
        public GetTemplateDetailsByIdHandler(ITemplateDetailsRepository templateDetailsRepository) 
        { 
            _templateDetailsRepository = templateDetailsRepository;
        }

        public async Task<ResponseModel<TemplateDetail>> Handle(GetTemplateDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            TemplateDetail templateDetail = await _templateDetailsRepository.GetTemplateDetailsById(request.Id);
            return new ResponseModel<TemplateDetail> { data= templateDetail, message="data received" };
        }
    }
}
