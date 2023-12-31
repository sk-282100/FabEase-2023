﻿using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForAdvertisement;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FanEase_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        readonly IMediator _mediator;
        public AdvertisementController(IMediator meadiator)
        {
            _mediator = meadiator;
        }


        [HttpGet("GetAllAdvertisements")]
        public async Task<IActionResult> GetAllAdvertisements()
        {

            ResponseModel<List<Advertisement>> advertisements = await _mediator.Send(new GetAllAdvertisementsQuery());
            if (advertisements.data.Count == 0)
            {
                throw new NullReferenceException("nothing in the list");
            }
            return Ok(advertisements);

        }


        [HttpGet("AdvertisementListScreen")]
        public async Task<IActionResult> AdvertisementListScreen()
        {

            ResponseModel<List<AdvertisementListVM>> advertisements = await _mediator.Send(new AdvertisementListScreenQuery());
            if (advertisements.data.Count == 0)
            {
                throw new NullReferenceException("nothing in the list");
            }
            return Ok(advertisements);

        }


        [HttpGet]
        [Route("AdvertisementListScreenByUserId/userId")]
        public async Task<IActionResult> AdvertisementListScreenByUserId(string userId)
        {

            ResponseModel<List<AdvertisementListVM>> advertisements = await _mediator.Send(new AdvertisementListScreenByUserIdQuery(userId));
            if (advertisements.data.Count == 0)
            {
                throw new NullReferenceException("nothing in the list");
            }
            return Ok(advertisements);

        }


        [HttpGet("GetAdvertisementById/{id}")]

        public async Task<IActionResult> GetAdvertisementById(int id)
        {
            ResponseModel<Advertisement> advertisement = await _mediator.Send(new GetAdvertisementByIdQuery(id));
            if (advertisement != null)
                return Ok(advertisement);
            return NotFound();
        }


        [HttpGet]
        [Route("GetAdvertisementsByUser/{userId}")]
        public async Task<IActionResult> GetAdvertisementsByUser(string userId)
        {
            ResponseModel<List<Advertisement>> response = await _mediator.Send(new GetAdvertisementsByUserQuery(userId));
            if (response.data.Count != 0)
                return Ok(response.data);
            return NotFound();
        }


        [HttpPost]
        [Route("AddAdvertisement")]
        public async Task<IActionResult> AddAdvertisement(Advertisement advertisement)
        {
            ResponseModel<bool> status = await _mediator.Send(new AddAdvertisementCommand(advertisement));
            if (status.data)
            {
                return Created("api/Created", status);
            }
            return BadRequest(status);
        }

        [HttpPut]
        [Route("EditAdvertisement")]
        public async Task<IActionResult> EditAdvertisement(Advertisement advertisement)
        {
            ResponseModel<bool> status = await _mediator.Send(new EditAdvertisementCommand(advertisement));
            if (status.data)
            {
                return Ok(advertisement);
            }

            return BadRequest();
        }

        [HttpDelete("DeleteAdvertisement/{id}")]
        public async Task<IActionResult> DeleteAdvertisement(int id)
        {
            ResponseModel<bool> status = await _mediator.Send(new DeleteAdvertisementCommand(id));
            if (status.data)
            {
                return Ok();
            }

            return NotFound();

        }

        [HttpGet]
        [Route("GetAdvertisementsofCampaign/{campaignId}")]
        public async Task<IActionResult> GetAdvertisementsofCampaign(int campaignId)
        {
            ResponseModel<List<AdvertisemenetForTemp>> response = await _mediator.Send(new GetAdvertisementsByCampaignQuery(campaignId));
            if (response.data.Count != 0)
                return Ok(response.data);
            return NotFound();
        }


        //[HttpPut("EditAdvertisement/{id}")]
        //public async Task<IActionResult> EditAdvertisement(int id)
        //{
        //    ResponseModel<bool> status = await _meadiator.Send(new EditAdvertisementByIdCommand(id));
        //    if(status.data)
        //    {
        //        return Ok();
        //    }
        //    return NotFound();
        //}













    }
}
