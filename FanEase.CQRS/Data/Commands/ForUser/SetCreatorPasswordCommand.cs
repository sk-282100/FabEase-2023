using ExceptionHandling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForUser
{
    public class SetCreatorPasswordCommand:IRequest<ResponseModel<bool>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public SetCreatorPasswordCommand(string USERNAME,string PASSWORD)
        {
            UserName=USERNAME;
            Password=PASSWORD;
        }
    }
}
