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
    internal class ResetPasswordHandler:IRequestHandler<ResetPasswordCommand, ResponseModel<bool>>
    {
        readonly IUserRepository _userRepository;
        public ResetPasswordHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseModel<bool>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.ResetPassword(request.NewPassword,request.OldPassword,request.UserId);
        }
    }
}
