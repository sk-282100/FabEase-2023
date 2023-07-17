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
    public class SetPasswordCommandHandler :IRequestHandler<SetPasswordCommand,ResponseModel<bool>>
    {
        readonly IUserRepository _userRepository;

        public SetPasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseModel<bool>> Handle(SetPasswordCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.SetPassword(request.UserName,request.Password);
        }
    }
}
