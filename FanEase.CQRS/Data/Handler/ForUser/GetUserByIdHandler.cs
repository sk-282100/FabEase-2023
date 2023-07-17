using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForUser;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForUser
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, ResponseModel<User>>
    {
        readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task <ResponseModel<User>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            User user= await _userRepository.GetUserById(request.Id);
            return new ResponseModel<User> { data=user,message="Data recived" };
        }
    }
}
