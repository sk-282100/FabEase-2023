using ExceptionHandling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForUser
{
    public class DeleteUserCommand : IRequest<ResponseModel<bool>>
    {
        public DeleteUserCommand(string id)
        {
            Id = id;
        }

        public string Id { get; }
    }
}
