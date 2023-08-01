using ExceptionHandling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForVideo
{
    public class AssignCampaignCommand :IRequest<ResponseModel<bool>>
    {
       public int? VideoId { get; set; }

        public int? CampaignId { get; set;}

        public AssignCampaignCommand(int? videoId, int? campaignId)
        {
            VideoId=videoId; CampaignId=campaignId;
        }
    }
}
