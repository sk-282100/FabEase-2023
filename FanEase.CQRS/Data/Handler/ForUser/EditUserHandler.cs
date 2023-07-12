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
    public class EditUserHandler : IRequestHandler<EditUserCommand, ResponseModel<bool>>
    {
        readonly IUserRepository _userRepository;

        public EditUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ResponseModel<bool>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            bool status= await _userRepository.EditUser(request.User);
            return new ResponseModel<bool> { data=status,message="User Edited" };
        }
    }
}
