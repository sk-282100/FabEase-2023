using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForState;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForState
{
    public class GetStateListHandler : IRequestHandler<GetStateListQuery, ResponseModel<List<State>>>
    {
        private readonly IStateRepository _stateRepository;

        public GetStateListHandler(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<ResponseModel<List<State>>> Handle(GetStateListQuery request, CancellationToken cancellationToken)
        {
            List<State> states = await _stateRepository.GetAllState();
            return new ResponseModel<List<State>>() { data = states, message = "Data Received" };
            //throw new NotImplementedException();
        }
    }
}
