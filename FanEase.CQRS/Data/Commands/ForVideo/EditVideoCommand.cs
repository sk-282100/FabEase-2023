﻿
using ExceptionHandling;
using FanEase.Entity.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForVideo
{

    public class EditVideoCommand : IRequest<ResponseModel<bool>>
    {
        public EditVideoCommand(Video video)
        {
              Video = video;
        }
         
        public Video Video { get; set; }

    }
}
