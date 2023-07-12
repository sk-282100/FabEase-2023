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
    public class GetAllCampaignIdQueryHandler : IRequestHandler<GetAllCampaignIdQuery, Response>
    {

        private readonly ICampaignRepository _campaignRepository;
        public GetAllCampaignIdQueryHandler(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }
        public async Task<Response> Handle(GetAllCampaignIdQuery request, CancellationToken cancellationToken)
        {

            Campaigns campaign = await _campaignRepository.GetCampaignById(request.campaignId);


            Response data = new Response
            {
                Result = campaign,
                Message = "Campaign found",
                IsSuccess = true
            };
            return data;

        }
    }
}
