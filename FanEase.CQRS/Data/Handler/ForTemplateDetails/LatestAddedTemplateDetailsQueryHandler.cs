using ExceptionHandling;
using FanEase.Middleware.Data.Queries.ForCampaign;
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
    public class LatestAddedTemplateDetailsQueryHandler : IRequestHandler<LatestAddedTemplateDetailsQuery, ResponseModel<int>>
    {
        readonly ITemplateDetailsRepository _templateDetailsRepository;

        public LatestAddedTemplateDetailsQueryHandler(ITemplateDetailsRepository templateDetailsRepository)
        {
            _templateDetailsRepository = templateDetailsRepository;
        }
        public async Task<ResponseModel<int>> Handle(LatestAddedTemplateDetailsQuery request, CancellationToken cancellationToken)
        {
            int CampaignId = await _templateDetailsRepository.LatestAddedTemplateDetails(request.UserId);
            return new ResponseModel<int> { data = CampaignId, message = "data received" };
        }
    }
}
