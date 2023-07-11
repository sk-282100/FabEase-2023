using ExceptionHandling;
using MediatR;

namespace FanEase_CQRS.Controllers
{
    public class DeleteAdvertisementCommand : IRequest<ResponseModel<bool>>
    {
        public int Id { get; set; }

        public DeleteAdvertisementCommand(int id)
        {
            Id=id;
        }
    }
}