using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Commands.ForCampaign;
using FanEase.Middleware.Data.Queries.ForCampaign;
using FanEase.Middleware.Data.Queries.ForVideo;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FanEase_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {

        private readonly IMediator _mediator;
        public CampaignController(IMediator mediator)
        {

            _mediator = mediator;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            ResponseModel<List <Campaigns>  > campaigns = await _mediator.Send(new GetAllCampaignsQuery());
            if (campaigns.data != null )
            {
                return Ok(campaigns);
            }
            return NotFound(campaigns);
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int campaignId)
        {
            ResponseModel<Campaigns> campaignResponse = await _mediator.Send(new GetAllCampaignIdQuery(campaignId));

            if (campaignResponse.data != null )
            {
                return Ok(campaignResponse);
            }

            return NotFound(campaignResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CampaignCreateCommand command)
        {
            ResponseModel<bool> campaigns = await _mediator.Send(command);
            if (campaigns != null )
            {
                return Ok(campaigns);
            }
            return NotFound(campaigns);
        }
        [HttpPut]

        public async Task<IActionResult> Put([FromBody] UpdateCampaignCommand commands)
        {
            ResponseModel<bool> campaigns = await _mediator.Send(commands);
            return Ok(campaigns);
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(int campaignId)
        {
            var command = new CampaignDeleteCommand { campaignId = campaignId };
            ResponseModel<bool> deleteResponse = await _mediator.Send(command);

            if (deleteResponse.data != false)
            {
                return Ok(deleteResponse);
            }

            return BadRequest(deleteResponse);
        }

        [HttpGet]
        [Route("GetAllCampaignListScreenByUserId/userId")]
        public async Task<IActionResult> GetAllCampaignListScreenByUserId(string userId)
        {

            ResponseModel<List<CampaignListScreenVm>> Campai = await _mediator.Send(new GetAllCampaignListScreenByUserIdQuery(userId));
            if (Campai.data.Count == 0)
            {
                throw new NullReferenceException("nothing in the list");
            }
            return Ok(Campai);

        }


        [HttpGet]
        [Route("LatestAddedCampaign/{userId}")]
        public async Task<IActionResult> LatestAddedCampaign(string userId)
        {
            ResponseModel<int> CampaignId = await _mediator.Send(new LatestAddedCampaignQuery(userId));
            return Ok(CampaignId);
        }
        /// <summary>
        /// Edit Campaign for the CampaignAdvertisement
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        //[HttpGet]
        //[Route("EditGetAllCampaignAdv/CampaignId")]
        //public async Task<IActionResult> EditGetAllCampaignAdv(int CampaignId)
        //{

        //    ResponseModel<EditCampaignVm> Campai = await _mediator.Send(new GetAllCampaignAdvIdQuery(CampaignId));
        //    if (Campai.data != null)
        //    {
        //        return Ok(Campai);
        //    }
        //    return NotFound(Campai);

        //}
    }
}
