using FanEase.Entity.Models;
using FanEase.Middleware.Data.Commands.ForPlayer;
using FanEase.Middleware.Data.Queries.ForPlayer;
using FanEase.Repository.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FanEase_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        
        private readonly IMediator _mediator;
        public PlayerController( IMediator mediator)
        {
            

            _mediator = mediator;
        }
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            Response players = await _mediator.Send(new GetAllPlayersQuery());
            if (players != null && players.IsSuccess)
            {
                return Ok(players);
            }
            return NotFound(players);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int palyerId)
        {
            Response playerResponse = await _mediator.Send(new GetAllPlayerIdQuery(palyerId));

            if (playerResponse != null && playerResponse.IsSuccess)
            {
                return Ok(playerResponse);
            }

            return NotFound(playerResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PlayerCreateCommand command)
        {
            Response players = await _mediator.Send(command);
            if (players != null && players.IsSuccess)
            {
                return Ok(players);
            }
            return NotFound(players);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdatePlayerCommand command)
        {

            Response updateResponse = await _mediator.Send(command);

            if (updateResponse != null && updateResponse.IsSuccess)
            {
                return Ok(updateResponse);
            }

            return NotFound(updateResponse);
        }

        [HttpDelete("{playerId}")]
        public async Task<IActionResult> Delete(int playerId)
        {
            var command = new PlayerDeleteCommand { palyerId = playerId };
            Response deleteResponse = await _mediator.Send(command);

            if (deleteResponse != null && deleteResponse.IsSuccess)
            {
                return Ok(deleteResponse);
            }

            return NotFound(deleteResponse);
        }

    }
}
