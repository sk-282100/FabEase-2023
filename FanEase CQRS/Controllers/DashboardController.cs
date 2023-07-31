using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForDashboard;
using FanEase.Middleware.Data.Queries.ForPlayer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FanEase_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> AdminDashBoard()
        {
            ResponseModel<AdminDashboardDTO> dashboard = await _mediator.Send(new AdminDashBoardQuery());

            if (dashboard.data != null)
                return Ok(dashboard);
            else
                return BadRequest(dashboard);

        }
    }
}
