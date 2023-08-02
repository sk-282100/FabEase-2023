using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Commands.ForCampaign;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForCampaign
{
    public class UpdateCampaignCommandHandler : IRequestHandler<UpdateCampaignCommand, ResponseModel<bool>>
    {
        private readonly ICampaignRepository _campaignRepository;
        public UpdateCampaignCommandHandler(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public async Task<ResponseModel<bool>> Handle(UpdateCampaignCommand request, CancellationToken cancellationToken)
        {
            EditCampaignVm editCampaignVm = new EditCampaignVm
            {
                campaignId = request.campaignId,
                name = request.name,
                startDate = request.startDate,
                endDate = request.endDate,
                engagement = request.engagement,
                userId = request.userId,
                //Advertisements = request.Advertisements
            };

            var rowsAffected = await _campaignRepository.UpdateCampaign(editCampaignVm);
            var response = new ResponseModel<bool> { data = false, message = "failed to Update campaign" };
            if (rowsAffected > 0)
            {
                response.data = true;
                response.message = "Campaign Updated successfully";
            }

            return response;
        }
    }
}
