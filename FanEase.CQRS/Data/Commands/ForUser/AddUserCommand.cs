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
    public class AddUserCommand : IRequest<ResponseModel<bool>>
    {
        public AddUserCommand(User user)
        {
            User = user;
        }

        public AddUserCommand(LoginDto logindto)
        {
            Logindto = logindto;
        }

        public User User { get; }
        public LoginDto Logindto { get; }
    }
}
