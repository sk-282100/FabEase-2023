using ExceptionHandling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForCampaign
{
    public class AssignAdvertisementCommand : IRequest<ResponseModel<bool>>
    {
        public int? CampaignId { get; set; }

        public int? AdvertisementId { get; set; }

        public AssignAdvertisementCommand(int? campaignId, int? advertisementId)
        {
            CampaignId = campaignId; AdvertisementId = advertisementId;
        }
    }
}