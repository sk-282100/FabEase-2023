using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForVideo;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ExceptionHandling;
using FanEase.Middleware.Data.Queries.ForState;
using FanEase.Middleware.Data.Commands.ForTemplate;
using FanEase.Middleware.Data.Commands.ForState;
using FanEase.Middleware.Data.Queries.ForTemplate;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FanEase_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        readonly IMediator _meadiator;

        public StateController(IMediator meadiator)
        {
            _meadiator = meadiator;
        }

        [HttpPost]
        public async Task<IActionResult> AddState(State state)
        {
            ResponseModel<bool> stateData = await _meadiator.Send(new StateCreateCommand(
                  state.StateName, state.CountryId));
            if (stateData.data)
            {
                return Created("api/Created", stateData);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteState(int id)
        {
            ResponseModel<bool> stateDelete = await _meadiator.Send(new StateDeleteCommand() { StateId = id });
            if (stateDelete.data)
            {
                return Ok();
            }

            return NotFound();
        }


        [HttpGet]
        public async Task<IActionResult> GetAllState()
        {
            ResponseModel<List<State>> states = await _meadiator.Send(new GetStateListQuery());
            return Ok(states);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateState(State state)
        {
            ResponseModel<bool> stateUpdate = await _meadiator.Send(new StateUpdateCommand(state));
            if (stateUpdate.data)
            {
                return Ok(state);
            }

            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStateById(int id)
        {
            ResponseModel<State> stateById = await _meadiator.Send(new GetStateListByIdQuery() { StateId = id });
            if (stateById != null)
                return Ok(stateById);
            return NotFound();
        }
    }
}
