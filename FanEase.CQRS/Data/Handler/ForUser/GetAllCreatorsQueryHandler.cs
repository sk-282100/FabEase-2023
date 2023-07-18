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
    public class GetAllCreatorsQueryHandler : IRequestHandler<GetAllCreatorsQuery, ResponseModel<List<User>>>
    {
        readonly IUserRepository _userRepository;
        public GetAllCreatorsQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ResponseModel<List<User>>> Handle(GetAllCreatorsQuery request, CancellationToken cancellationToken)
        {
            List<User> creators = await _userRepository.GetAllCreators();
            return new ResponseModel<List<User>> { data = creators, message = "Data recived" };
        }
    }
}
