using ExceptionHandling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForUser
{
    public class AddViewerCommand : IRequest<ResponseModel<bool>>
    {
      public string ViewerId { get; set; }
       public AddViewerCommand(string userId)
       {
         ViewerId = userId;
       }
    }
}
