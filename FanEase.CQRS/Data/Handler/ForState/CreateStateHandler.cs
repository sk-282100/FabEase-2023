using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Commands.ForState;
using FanEase.Repository.Interfaces;
using FanEase.Repository.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForState
{
    public class CreateStateHandler : IRequestHandler<StateCreateCommand, ResponseModel<bool>>
    {
        private readonly IStateRepository _stateRepository;

        public CreateStateHandler(IStateRepository stateRepository) 
        { 
            _stateRepository = stateRepository;
        }

        public async Task<ResponseModel<bool>> Handle(StateCreateCommand request, CancellationToken cancellationToken)
        {
            State state = new State
            {
                StateName = request.StateName,
                CountryId = request.CountryId
            };
            bool status = await _stateRepository.AddState(state);
            return new ResponseModel<bool> { data = status, message="State Added"};
        }
    }
}
