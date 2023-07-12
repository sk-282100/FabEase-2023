﻿using FanEase.Entity.Models;
using FanEase.Middleware.Data.Commands.ForCampaign;
using FanEase.Middleware.Data.Queries.ForCampaign;
using FanEase.Repository.Interfaces;
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
        public CampaignController( IMediator mediator)
        {
           
            _mediator = mediator;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            Response campaigns = await _mediator.Send(new GetAllCampaignsQuery());
            if (campaigns != null && campaigns.IsSuccess)
            {
                return Ok(campaigns);
            }
            return NotFound(campaigns);
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int campaignId)
        {
            Response campaignResponse = await _mediator.Send(new GetAllCampaignIdQuery(campaignId));

            if (campaignResponse != null && campaignResponse.IsSuccess)
            {
                return Ok(campaignResponse);
            }

            return NotFound(campaignResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CampaignCreateCommand command)
        {
            Response campaigns = await _mediator.Send(command);
            if (campaigns != null && campaigns.IsSuccess)
            {
                return Ok(campaigns);
            }
            return NotFound(campaigns);
        }
        [HttpPut]

        public async Task<IActionResult> Put([FromBody] UpdateCampaignCommand commands)
        {
            Response campaigns = await _mediator.Send(commands);
            return Ok(campaigns);
        }



        [HttpDelete]
        public async Task<IActionResult> Delete(int campaignId)
        {
            var command = new CampaignDeleteCommand { campaignId = campaignId };
            Response deleteResponse = await _mediator.Send(command);

            if (deleteResponse != null && deleteResponse.IsSuccess)
            {
                return Ok(deleteResponse);
            }

            return NotFound(deleteResponse);
        }


    }
}
