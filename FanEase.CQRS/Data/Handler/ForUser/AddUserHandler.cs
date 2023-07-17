using ExceptionHandling;
using FanEase.Entity.Models;
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
    public class AddUserHandler : IRequestHandler<AddUserCommand, ResponseModel<bool>>
    {
        readonly IUserRepository _userRepository;
        public AddUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseModel<bool>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            bool status= await _userRepository.AddUser(request.User);
            return new ResponseModel<bool>{ data=status, message="user Added"};
        }
    }
}
