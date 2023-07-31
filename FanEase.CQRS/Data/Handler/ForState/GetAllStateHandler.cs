using Azure;
using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForState;
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
    public class GetAllStateHandler : IRequestHandler<GetStateListByIdQuery, ResponseModel<State>>
    {
        private readonly IStateRepository _stateRepository;

        public GetAllStateHandler(IStateRepository stateRepository) 
        {
            _stateRepository = stateRepository;
        }

        public async Task<ResponseModel<State>> Handle(GetStateListByIdQuery request, CancellationToken cancellationToken)
        {
            State states = await _stateRepository.GetStateById(request.StateId);
            return new ResponseModel<State>() { data = states, message = "Data Received" };
            //throw new NotImplementedException();
        }
    }
}
