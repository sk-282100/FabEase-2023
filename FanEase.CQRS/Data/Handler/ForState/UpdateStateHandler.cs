using ExceptionHandling;
using FanEase.Middleware.Data.Commands.ForState;
using FanEase.Middleware.Data.Commands.ForTemplate;
using FanEase.Repository.Interfaces;
using FanEase.Repository.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForState
{
    public class UpdateStateHandler : IRequestHandler<StateUpdateCommand, ResponseModel<bool>>
    {
        private readonly IStateRepository _stateRepository;

        public UpdateStateHandler(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<ResponseModel<bool>> Handle(StateUpdateCommand request, CancellationToken cancellationToken)
        {
            bool status = await _stateRepository.UpdateState(request.State);
            return new ResponseModel<bool> { data = status, message = "State Edited" };
        }
    }
}