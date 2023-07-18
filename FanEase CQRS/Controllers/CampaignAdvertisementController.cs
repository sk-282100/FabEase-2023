using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Commands.ForCampaignAdvertisement;
using FanEase.Middleware.Data.Queries.ForCampaignAdvertisement;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FanEase_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignAdvertisementController : ControllerBase
    {

        private readonly IMediator _mediator;
        public CampaignAdvertisementController(IMediator mediator)
        {

            _mediator = mediator;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            ResponseModel<List<Campaign_Advertisement>> campaigns = await _mediator.Send(new GetAllCampaignAdvertisementsQuery());
            if (campaigns != null && campaigns.Succeed)
            {
                return Ok(campaigns);
            }
            return NotFound(campaigns);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int Id)
        {
            ResponseModel<Campaign_Advertisement> campaignResponse = await _mediator.Send(new GetAllCampaignAdvertisementIdQuery(Id));

            if (campaignResponse != null && campaignResponse.Succeed)
            {
                return Ok(campaignResponse);
            }

            return NotFound(campaignResponse);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CampaignAdvertisementCreateCommand command)
        {
            ResponseModel<bool> campaigns = await _mediator.Send(command);
            if (campaigns != null && campaigns.Succeed)
            {
                return Ok(campaigns);
            }
            return NotFound(campaigns);
        }
        [HttpPut]

        public async Task<IActionResult> Put([FromBody] UpdateCampaignAdvertisementCommand commands)
        {
            ResponseModel<bool> campaigns = await _mediator.Send(commands);
            return Ok(campaigns);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            var command = new CampaignAdvertisementDeleteCommand { Id = Id };
            ResponseModel<bool> deleteResponse = await _mediator.Send(command);

            if (deleteResponse != null && deleteResponse.Succeed)
            {
                return Ok(deleteResponse);
            }

            return NotFound(deleteResponse);
        }

    }
}
