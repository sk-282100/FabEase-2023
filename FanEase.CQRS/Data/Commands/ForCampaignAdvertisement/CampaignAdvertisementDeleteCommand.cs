﻿using ExceptionHandling;
using FanEase.Entity.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForCampaignAdvertisement
{
    public class CampaignAdvertisementDeleteCommand : IRequest<ResponseModel<bool>>
    {
        public int Id { get; set; }
    }
}