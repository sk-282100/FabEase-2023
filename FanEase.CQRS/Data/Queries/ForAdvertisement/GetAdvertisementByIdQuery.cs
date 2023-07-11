using ExceptionHandling;
using FanEase.Entity.Models;
using MediatR;

namespace FanEase_CQRS.Controllers
{
    public class GetAdvertisementByIdQuery : IRequest<ResponseModel<Advertisement>>
    {
        public int Id { get; set; }

        public GetAdvertisementByIdQuery(int id)
        {
            Id=id;
        }
    }
}