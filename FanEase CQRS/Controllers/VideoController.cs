
using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware;
using FanEase.Middleware.Data.Commands.ForVideo;
using FanEase.Middleware.Data.Queries.ForVideo;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace FanEase_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        readonly IMediator _meadiator;

        public VideoController(IMediator meadiator)
        {
            _meadiator = meadiator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVideos()
        {

            ResponseModel<List<Video>> videos = await _meadiator.Send(new GetAllVideosQuery());
            
            return Ok(videos);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVideoById(int id) 
        {
            ResponseModel<Video> video = await _meadiator.Send(new GetVideoByIdQuery(id));
            if(video != null) 
            return Ok(video);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddVideo(Video video)
        {
            ResponseModel<bool> status = await _meadiator.Send(new AddVideoCommand(video));
            if (status.data)
            {
                return Created("api/Created", status);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> EditVideo(Video video)
        {
            ResponseModel<bool> status = await _meadiator.Send(new EditVideoCommand(video));
            if(status.data)
            {
                return Ok(video);
            }

             return BadRequest(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVideo(int id)
        {
            ResponseModel<bool> status = await _meadiator.Send(new DeleteVideoCommand(id));
            if (status.data)
            {
                return Ok();
            }

            return NotFound();

        }

        [HttpGet]
        [Route("user/{userId}")]
        public async Task<IActionResult> GetVideosByUserId(string userId)
        {
            ResponseModel<List<Video>> result = await _meadiator.Send(new GetVideosByUserIdQuery(userId));
            if (result.data.Count != 0)
                return Ok(result.data);
            return NotFound();
        }

    }
}
