using ExceptionHandling;
using FanEase.Entity.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForState
{
    public class StateUpdateCommand : IRequest<ResponseModel<bool>>
    {
        public StateUpdateCommand(State state) {
            State = state;
        }

        public State State { get; set; }
    }
}
