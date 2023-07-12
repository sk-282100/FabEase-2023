using FanEase.Entity.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForCampaignAdvertisement
{
    public class CampaignAdvertisementCreateCommand : IRequest<Response>
    {
        public int campaignId { get; set; }
        public int advertisementId { get; set; }
    }
}
