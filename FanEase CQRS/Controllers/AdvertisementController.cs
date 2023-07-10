﻿using ExceptionHandling;
using FanEase.Entity.Models;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace FanEase_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvertisementController : ControllerBase
    {
        readonly IMediator _meadiator;
        public AdvertisementController(IMediator meadiator)
        {
            _meadiator = meadiator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAdvertisements()
        {
            
            ResponseModel<List<Advertisement>> advertisements = await _meadiator.Send(new GetAllAdvertisementsQuery());
            if (advertisements == null)
            {
                throw new NullReferenceException("nothing in the list");
            }
            return Ok(advertisements);

        }
        
        [HttpGet("{id}")]

        public async Task<IActionResult> GetAdvertisementById(int id)
        {
            ResponseModel<Advertisement> advertisement = await _meadiator.Send(new GetAdvertisementByIdQuery(id));
            if (advertisement != null)
                return Ok(advertisement);
            return NotFound();
        }

       /*
        [HttpGet("{UserId}")]
        public async Task<IActionResult> GetAdvertisementsByUser(string userId)
        {
            List<Advertisement> advertisements = await _meadiator.Send(new GetAdvertisementsByUserQuery(userId));
            if (advertisements != null)
                return Ok(advertisements);
            return NotFound();
        }
       */

        [HttpPost]
        public async Task<IActionResult> AddAdvertisement(Advertisement advertisement)
        {
            ResponseModel<bool> status = await _meadiator.Send(new AddAdvertisementCommand(advertisement));
            if (status.data)
            {
                return Created("api/Created", status);
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> EditAdvertisement(Advertisement advertisement)
        {
            ResponseModel<bool> status = await _meadiator.Send(new EditAdvertisementCommand(advertisement));
            if (status.data)
            {
                return Ok(advertisement);
            }

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdvertisement(int id)
        {
            ResponseModel<bool> status = await _meadiator.Send(new DeleteAdvertisementCommand(id));
            if (status.data)
            {
                return Ok();
            }

            return NotFound();

        }

    }
}
