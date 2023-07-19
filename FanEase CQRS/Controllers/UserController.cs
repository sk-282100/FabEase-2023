using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Commands.ForUser;
using FanEase.Middleware.Data.Queries.ForUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FanEase_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IMediator _meadiator;

        public UserController(IMediator meadiator)
        {
            _meadiator = meadiator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {

            ResponseModel<List<User>> users = await _meadiator.Send(new GetAllUsersQuery());
            return Ok(users);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            ResponseModel<User> user = await _meadiator.Send(new GetUserByIdQuery(id));
            if (user != null)
                return Ok(user);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            ResponseModel<bool> status = await _meadiator.Send(new AddUserCommand(user));
            if (status.data)
            {
                return Created("api/Created", status);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> EditUser(User user)
        {
           ResponseModel<bool> status = await _meadiator.Send(new EditUserCommand(user));
            if (status.data)
            {
                return Ok(user);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            ResponseModel<bool> status = await _meadiator.Send(new DeleteUserCommand(id));
            if (status.data)
            {
                return Ok();
            }

            return NotFound();

        }

        [HttpGet]
        [Route("GetByUserName/{userName}")]
        public async Task<IActionResult> GetUserByName(string userName)
        {
            ResponseModel<User> user = await _meadiator.Send(new GetUserByUserNameQuery(userName));
            if (user != null)
                return Ok(user);
            return NotFound();
        }

        [HttpGet]
        [Route("/creatorlist")]
        public async Task<ActionResult> GetCreatorList()
        {
            ResponseModel<List<User>> users = await _meadiator.Send(new GetAllCreatorsQuery());
            return Ok(users);
        }

        [HttpGet]
        [Route("AddCreator/{creatorId}")]
        public async Task<ActionResult> AddCreator(string creatorId)
        {
            ResponseModel<bool> result = await _meadiator.Send(new AddCreatorCommand(creatorId));
            if(result.data)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet]
        [Route("RemoveCreator/{creatorId}")]
        public async Task<ActionResult> RemoveCreator(string creatorId)
        {
            bool result = await _meadiator.Send(new RemoveCreatorCommand(creatorId));
            if(result)
                return Ok(result);
            return BadRequest(result);
        }

       
    }
}
