using ExceptionHandling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForState
{
    public class StateDeleteCommand : IRequest<ResponseModel<bool>>
    {
        public int StateId { get; set; }
    }
}
