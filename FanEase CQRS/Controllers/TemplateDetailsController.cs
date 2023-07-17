
using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Commands.ForTemplateDetails;
using FanEase.Middleware.Data.Queries.ForTemplateDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FanEase_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateDetailsController : ControllerBase
    {
        readonly IMediator _mediator;
        public TemplateDetailsController(IMediator mediator)
        {
            _mediator= mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTemplateDetails()
        {
            ResponseModel<List<TemplateDetail>> templateDetails = await _mediator.Send(new GetAllTemplateDetailsQuery());
            return Ok(templateDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTemplateDetailsById(int id)
        {
            ResponseModel<TemplateDetail> templateDetail = await _mediator.Send(new GetTemplateDetailsByIdQuery(id));
            return Ok(templateDetail);
        }

        [HttpPost]
        public async Task<IActionResult> AddTemplateDetails(TemplateDetail templateDetail)
        {
            ResponseModel<bool> status = await _mediator.Send(new AddTemplateDetailsCommand(templateDetail));
            if(status.data)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> EditTemplateDetails(TemplateDetail templateDetail)
        {
            ResponseModel<bool> status = await _mediator.Send(new EditTemplateDetailsCommand(templateDetail));

            if (status.data)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteTempletDetails(int id)
        {
            ResponseModel<bool> status = await _mediator.Send(new DeleteTemplateDetailsCommand(id));

            if (status.data)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
