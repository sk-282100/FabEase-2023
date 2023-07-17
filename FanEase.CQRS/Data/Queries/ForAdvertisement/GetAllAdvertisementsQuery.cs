using ExceptionHandling;
using FanEase.Entity.Models;
using MediatR;

namespace FanEase_CQRS.Controllers
{
    public class GetAllAdvertisementsQuery : IRequest<ResponseModel<List<Advertisement>>>
    {
        public GetAllAdvertisementsQuery()
        {
            
        }
    }
}