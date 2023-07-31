using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Commands.ForCampaign;
using FanEase.Middleware.Data.Commands.ForCountry;
using FanEase.Middleware.Data.Queries.ForCampaign;
using FanEase.Middleware.Data.Queries.ForCountry;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FanEase_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CountryController(IMediator mediator)
        {

            _mediator = mediator;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetCountry()
        {
            ResponseModel<List<Country>> countries = await _mediator.Send(new GetAllCountrysQuery());
            if (countries.data != null)
            {
                return Ok(countries);
            }
            return NotFound(countries);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetByCountryId(int countryId)
        {
            ResponseModel<Country> countryResponse = await _mediator.Send(new GetAllCountryIdQuery(countryId));

            if (countryResponse.data != null)
            {
                return Ok(countryResponse);
            }

            return NotFound(countryResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CountryCreateCommand command)
        {
            ResponseModel<bool> country = await _mediator.Send(command);
            if (country != null)
            {
                return Ok(country);
            }
            return NotFound(country);
        }

        [HttpPut]

        public async Task<IActionResult> Put([FromBody] UpdateCountryCommand commands)
        {
            ResponseModel<bool> country = await _mediator.Send(commands);
            return Ok(country);
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int countryId)
        {
            var command = new CountryDeleteCommand { CountryId = countryId };
            ResponseModel<bool> deleteResponse = await _mediator.Send(command);

            if (deleteResponse.data != false)
            {
                return Ok(deleteResponse);
            }

            return BadRequest(deleteResponse);
        }

        [HttpGet]
        [Route("GetByName")]
        public async Task<IActionResult> GetByCountryName(string CountryName)
        {
            ResponseModel<Country> countryResponse = await _mediator.Send(new CheckCountryNameExistsQuery(CountryName));

            if (countryResponse.data != null)
            {
                return Ok(countryResponse);
            }

            return NotFound(countryResponse);
        }
    }
}
