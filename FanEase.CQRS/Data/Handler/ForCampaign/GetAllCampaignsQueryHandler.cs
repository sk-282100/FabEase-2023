using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForCampaign;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForCampaign
{
    public class GetAllCampaignsQueryHandler : IRequestHandler<GetAllCampaignsQuery, ResponseModel<List<Campaigns>>>
    {
        private readonly ICampaignRepository _campaignRepository;
        public GetAllCampaignsQueryHandler(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }
        public async Task<ResponseModel<List<Campaigns>>> Handle(GetAllCampaignsQuery request, CancellationToken cancellationToken)
        {
            List<Campaigns> campaigns = await _campaignRepository.GetAllCampaigns();
          
            return new ResponseModel<List<Campaigns>> { data= campaigns , message="Campaign Received"};
        }
    }
}
