using ExceptionHandling;
using FanEase.Middleware.Data.Commands.ForUser;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, ResponseModel<bool>>
    {
        readonly IUserRepository _userRepository;
        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseModel<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            bool status=await _userRepository.DeleteUser(request.Id);
            return new ResponseModel<bool> { data = status, message = "User deleted" };
        }
    }
}
