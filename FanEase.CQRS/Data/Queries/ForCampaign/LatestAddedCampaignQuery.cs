using ExceptionHandling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Queries.ForCampaign
{
    public class LatestAddedCampaignQuery : IRequest<ResponseModel<int>>
    {
        public string UserId { get; set; }

        public LatestAddedCampaignQuery(string userId)
        {
            UserId = userId;
        }
    }
}
