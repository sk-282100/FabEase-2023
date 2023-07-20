using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForUser
{
    public class RemoveCreatorCommandHandler : IRequestHandler<RemoveCreatorCommand,bool>
    {
        readonly IUserRepository _userRepository;

        public RemoveCreatorCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<bool> Handle(RemoveCreatorCommand request, CancellationToken cancellationToken)
        {
            return  _userRepository.RemoveCreator(request.CreatorId);
        }
    }
}
