using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForUser;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForUser
{
    public class GetUserByUserNameQueryHandler : IRequestHandler<GetUserByUserNameQuery, ResponseModel<User>>
    {
        readonly IUserRepository _userRepository;
        public GetUserByUserNameQueryHandler(IUserRepository userRepository)
        {
            _userRepository= userRepository;
        }
        public async Task<ResponseModel<User>> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            User user = await _userRepository.GetUserByUserName(request.UserName);
            return new ResponseModel<User> { data = user, message = "Data recived" };
        }
    }
}
