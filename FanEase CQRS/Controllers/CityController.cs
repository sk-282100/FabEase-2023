using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Commands.ForCity;
using FanEase.Middleware.Data.Commands.ForState;
using FanEase.Middleware.Data.Queries.ForCity;
using FanEase.Middleware.Data.Queries.ForState;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FanEase_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
            readonly IMediator _meadiator;

            public CityController(IMediator meadiator)
            {
                _meadiator = meadiator;
            }

            [HttpPost]
            public async Task<IActionResult> AddCity(City city)
            {
                ResponseModel<bool> cityData = await _meadiator.Send(new CityCreateCommand(
                      city.CityName, city.StateId));
                if (cityData.data)
                {
                    return Created("api/Created", cityData);
                }
                return BadRequest();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteCity(int id)
            {
                ResponseModel<bool> cityDelete = await _meadiator.Send(new CityeDeleteCommand() { CityId = id });
                if (cityDelete.data)
                {
                    return Ok();
                }

                return NotFound();
            }


            [HttpGet]
            public async Task<IActionResult> GetAllCities()
            {
                ResponseModel<List<CityListVM>> cities = await _meadiator.Send(new GetCityListQuery());
                return Ok(cities);
            }

            [HttpPut]
            public async Task<IActionResult> UpdateCity(City city)
            {
                ResponseModel<bool> cityUpdate = await _meadiator.Send(new CityUpdateCommand(city));
                if (cityUpdate.data)
                {
                    return Ok(city);
                }

                return BadRequest();
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetCityById(int id)
            {
                ResponseModel<City> cityById = await _meadiator.Send(new GetCityListByIdQuery() { CityId = id });
                if (cityById != null)
                    return Ok(cityById);
                return NotFound();
            }
        }
}
