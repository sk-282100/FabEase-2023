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
    public class GetTemplateDetailsByIdHandler : IRequestHandler<GetTemplateDetailsByIdQuery,TemplateDetail>
    {
        readonly ITemplateDetailsService _templateDetailsService;
        public GetTemplateDetailsByIdHandler(ITemplateDetailsService templateDetailsService) 
        { 
            _templateDetailsService = templateDetailsService;
        }

        public async Task<TemplateDetail> Handle(GetTemplateDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            return await _templateDetailsService.GetTemplateDetailsById(request.Id);
        }
    }
}
