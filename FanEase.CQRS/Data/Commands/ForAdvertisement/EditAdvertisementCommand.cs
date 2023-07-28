using ExceptionHandling;
using FanEase.Entity.Models;
using MediatR;

namespace FanEase_CQRS.Controllers
{
    public class EditAdvertisementCommand : IRequest<ResponseModel<bool>>
    {
        public Advertisement Advertisement {get; set;}

        public EditAdvertisementCommand(Advertisement advertisement)
        {
            Advertisement = advertisement;
        }

    }
}