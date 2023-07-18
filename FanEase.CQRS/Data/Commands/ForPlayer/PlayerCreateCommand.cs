using ExceptionHandling;
using FanEase.Entity.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForPlayer
{
    public class PlayerCreateCommand : IRequest<ResponseModel<bool>>
    {
        public string name { get; set; }
        public string position { get; set; }
        public int jerseyNo { get; set; }
        public int teamId { get; set; }
    }
}
