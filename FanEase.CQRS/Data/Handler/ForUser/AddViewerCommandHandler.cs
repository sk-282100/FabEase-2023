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
    public class AddViewerCommandHandler : IRequestHandler<AddViewerCommand, ResponseModel<bool>>
    {
        readonly IUserRepository _userRepository;
        public AddViewerCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ResponseModel<bool>> Handle(AddViewerCommand request, CancellationToken cancellationToken)
        {
            bool result = await _userRepository.AddViewer(request.ViewerId);
            if (result)
            {
                return new ResponseModel<bool>()
                {
                    data = true,
                    message = "viewer added to thelist"
                };
            }
            return new ResponseModel<bool>()
            {
                data = false,
                message = "failed to add"
            };
        }
    }
}
