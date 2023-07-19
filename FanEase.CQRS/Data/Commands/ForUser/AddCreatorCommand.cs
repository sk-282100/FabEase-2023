﻿using ExceptionHandling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForUser
{
    public class AddCreatorCommand : IRequest<ResponseModel<bool>>
    {
        public string CreatorId { get; set; }
        public AddCreatorCommand(string userId)
        {
            CreatorId = userId;
        }
    }
}
