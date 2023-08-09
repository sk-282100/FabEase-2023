using ExceptionHandling;
using FanEase.Middleware.Data.Queries.ForTemplate;
using FanEase.Middleware.Data.Queries.ForTemplateDetails;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForTemplate
{
    public class LatestAddedTemplateQueryHandler : IRequestHandler<LatestAddedTemplateQuery, ResponseModel<int>>
    {
        readonly ITemplateRepository _templateRepository;

        public LatestAddedTemplateQueryHandler(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }
        public async Task<ResponseModel<int>> Handle(LatestAddedTemplateQuery request, CancellationToken cancellationToken)
        {
            int CampaignId = await _templateRepository.LatestAddedTemplate(request.UserId);
            return new ResponseModel<int> { data = CampaignId, message = "data received" };
        }
    }
}
