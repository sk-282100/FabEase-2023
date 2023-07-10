using ExceptionHandling;
using FanEase.Entity.Models;
using MediatR;

namespace FanEase_CQRS.Controllers
{
    public class GetAdvertisementsByUserQuery : IRequest<ResponseModel<List<Advertisement>>>
    {
        public GetAdvertisementsByUserQuery(string userId)
        {

            UserId = userId;

        }

        public string UserId { get; set; }
    }
}