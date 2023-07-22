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
    public class EditUserHandler : IRequestHandler<EditUserCommand, ResponseModel<bool>>
    {
        readonly IUserRepository _userRepository;

        public EditUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ResponseModel<bool>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            User user1 = await _userRepository.GetUserByUserName(request.User.Email);

            User user2 = await _userRepository.GetUserByContactNo(request.User.ContactNo);
            if (user1 != null && user1.UserId != request.User.UserId)
            {
                return new ResponseModel<bool> { Succeed = false, message = "Email Exists" };
            }
            if (user2 != null && user1.UserId != request.User.UserId)
            {
                return new ResponseModel<bool> { Succeed = false, message = "ContactNo Exists" };
            }
            bool status= await _userRepository.EditUser(request.User);
            return new ResponseModel<bool> { data=status,message="User Edited" };
        }
    }
}
