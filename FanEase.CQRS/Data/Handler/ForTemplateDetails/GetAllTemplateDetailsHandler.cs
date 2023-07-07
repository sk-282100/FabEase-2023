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
    public class GetAllTemplateDetailsHandler : IRequestHandler<GetAllTemplateDetailsQuery,List<TemplateDetail>>
    {
        readonly ITemplateDetailsService _templateDetailsService;
        public GetAllTemplateDetailsHandler(ITemplateDetailsService templateDetailsService)
        {
             _templateDetailsService = templateDetailsService;
        }

        public async Task<List<TemplateDetail>> Handle(GetAllTemplateDetailsQuery request, CancellationToken cancellationToken)
        {
            return await _templateDetailsService.GetAllTempletDetails();
        }
    }
}
