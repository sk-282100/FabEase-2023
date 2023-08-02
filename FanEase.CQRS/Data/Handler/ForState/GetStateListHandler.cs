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
    public class GetStateListHandler : IRequestHandler<GetStateListQuery, ResponseModel<List<StateListVM>>>
    {
        private readonly IStateRepository _stateRepository;

        public GetStateListHandler(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<ResponseModel<List<StateListVM>>> Handle(GetStateListQuery request, CancellationToken cancellationToken)
        {
            List<StateListVM> states = await _stateRepository.GetAllState();
            return new ResponseModel<List<StateListVM>>() { data = states, message = "Data Received" };
            //throw new NotImplementedException();
        }
    }
}
