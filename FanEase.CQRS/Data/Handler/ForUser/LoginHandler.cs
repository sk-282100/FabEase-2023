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
    public class LoginHandler : IRequestHandler<LoginCommand, ResponseModel<AuthResponse>>
    {
        readonly IUserRepository _userRepository;
        public LoginHandler(IUserRepository userRepository)
        {
            _userRepository= userRepository;
        }
        public async Task<ResponseModel<AuthResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.Login(request.LoginDto);
        }
    }
}
