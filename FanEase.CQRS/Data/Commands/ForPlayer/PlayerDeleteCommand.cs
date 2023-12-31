﻿using ExceptionHandling;
using FanEase.Entity.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForPlayer
{
    public class PlayerDeleteCommand : IRequest<ResponseModel<bool>>
    {
        public int palyerId { get; set; }
    }
}
