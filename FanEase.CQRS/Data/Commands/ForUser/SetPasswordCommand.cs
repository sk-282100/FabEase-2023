using ExceptionHandling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForUser
{
    public class SetPasswordCommand : IRequest<ResponseModel<bool>>
    {
        public string Password { get; set; }
        public string UserName { get; set; }


        public SetPasswordCommand(string userName, string password)
        {
            Password = password;
            UserName = userName;
        }
    }
}
