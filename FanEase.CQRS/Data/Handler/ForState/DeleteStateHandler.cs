using ExceptionHandling;
using FanEase.Middleware.Data.Commands.ForState;
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
    public class DeleteStateHandler : IRequestHandler<StateDeleteCommand, ResponseModel<bool>>
    {
        private readonly IStateRepository _stateRepository; 

        public DeleteStateHandler(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<ResponseModel<bool>> Handle(StateDeleteCommand request, CancellationToken cancellationToken)
        {
            var state = await _stateRepository.GetStateById(request.StateId);
            if (state == null)
            {
                return default;
            }
            bool status = await _stateRepository.DeleteState(request.StateId);
            return new ResponseModel<bool> { data = status, message = "State deleted" };
        }
    }
}
