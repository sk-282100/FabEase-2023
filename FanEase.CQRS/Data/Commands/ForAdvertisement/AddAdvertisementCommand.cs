using ExceptionHandling;
using FanEase.Entity.Models;
using MediatR;

namespace FanEase_CQRS.Controllers
{
    public class AddAdvertisementCommand : IRequest<ResponseModel<bool>>
    {
        public AddAdvertisementCommand(Advertisement advertisement)
        {
            Advertisement = advertisement;
        }

        public Advertisement Advertisement { get; set; }
    }
}