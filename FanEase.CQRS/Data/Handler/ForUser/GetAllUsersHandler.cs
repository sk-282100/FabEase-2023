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
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, ResponseModel<List<User>>>
    {
        readonly IUserRepository _userRepository;
        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseModel<List<User>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
             List<User> user= await _userRepository.GetAllUsers();
            return new ResponseModel<List<User>> { data=user,message="Data recived" };
        }
    }
}
