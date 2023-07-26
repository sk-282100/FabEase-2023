using ExceptionHandling;
using FanEase.Entity.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Queries.ForAdvertisement
{
    public class AdvertisementListScreenByUserIdQuery : IRequest<ResponseModel<List<AdvertisementListVM>>>
    {
        

        public AdvertisementListScreenByUserIdQuery(string userId)
        {
            this.UserId = userId;
        }

        public string UserId { get; internal set; }
    }
}
