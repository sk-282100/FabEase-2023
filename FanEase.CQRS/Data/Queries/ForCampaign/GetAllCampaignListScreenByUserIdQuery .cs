using ExceptionHandling;
using FanEase.Entity.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Queries.ForCampaign
{
    public class GetAllCampaignListScreenByUserIdQuery : IRequest<ResponseModel<List<CampaignListScreenVm>>>
    {
        public GetAllCampaignListScreenByUserIdQuery(string userId)
        {
            this.userId = userId;
        }

        public string userId { get; set; }
    }
}
