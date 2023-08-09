using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Commands.ForTemplate;
using FanEase.Middleware.Data.Queries.ForTemplate;
using FanEase.Middleware.Data.Queries.ForTemplateDetails;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FanEase_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private IMediator _mediator;

        public TemplateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddTemplate(Templates templates)
        {
            ResponseModel<bool> templateData = await _mediator.Send(new CreateTemplateCommand(templates));
            if (templateData.data)
            {
                return Created("api/Created", templateData);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemplates(int id)
        {
            ResponseModel<bool> templateDelete = await _mediator.Send(new DeleteTemplateCommand() { TemplateId = id });
            if (templateDelete.data)
            {
                return Ok(templateDelete);
            }

            return NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTemplates(Templates templates)
        {
            ResponseModel<bool> templateUpdate = await _mediator.Send(new UpdateTemplateCommand(templates));
            if (templateUpdate.data)
            {
                return Ok(templates);
            }

            return BadRequest();
        }

        [HttpGet]
        [Route("GetAllTemplates")]
        public async Task<IActionResult> GetAllTemplates()
        {
            ResponseModel<List<TemplateListDTO>> templateList = await _mediator.Send(new GetTemplateListQuery());

            return Ok(templateList);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTemplateById(int id)
        {
            ResponseModel<Templates> templatesById = await _mediator.Send(new GetTemplateListByIdQuery() { TemplateId = id });
            if (templatesById != null)
                return Ok(templatesById);
            return NotFound();
        }

        [HttpGet]
        [Route("GetAllTemplatesByUser/{userId}")]
        public async Task<IActionResult> GetAllTemplatesByUser(string userId)
        {
            ResponseModel<List<TemplateListDTO>> templatesById = await _mediator.Send(new GetAllTemplatesByUserQuery() { UserId = userId });
            if (templatesById != null)
                return Ok(templatesById);
            return NotFound(templatesById);
        }

        [HttpGet]
        [Route("LatestAddedTemplate/{userId}")]
        public async Task<IActionResult> LatestAddedTemplate(string userId)
        {
            ResponseModel<int> CampaignId = await _mediator.Send(new LatestAddedTemplateQuery(userId));
            return Ok(CampaignId);
        }
    }
}
