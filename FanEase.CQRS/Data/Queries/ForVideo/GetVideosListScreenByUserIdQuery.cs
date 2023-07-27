using ExceptionHandling;
using FanEase.Entity.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Queries.ForVideo
{
    public class GetVideosListScreenByUserIdQuery : IRequest<ResponseModel<List<VideoListVm>>>
    {
        public GetVideosListScreenByUserIdQuery(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; set; }


    }
}
