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
    public class EditUserCommand : IRequest<ResponseModel<bool>>
    {
        public EditUserCommand(User user)
        {
            User = user;
        }

        public User User { get; }
    }
}
