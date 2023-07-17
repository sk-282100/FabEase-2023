using ExceptionHandling;
using FanEase.Entity.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForUser
{
    public class LoginCommand : IRequest<ResponseModel<AuthResponse>>
    {
        public LoginDto LoginDto { get; set; }

        public LoginCommand(LoginDto loginDto)
        {
                LoginDto = loginDto;
        }
    }
}
