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
    public class GetVideoByCreatorIdQuery : IRequest<ResponseModel<List<Video>>>
    {
        public string CreatorId { get; set; }

        public GetVideoByCreatorIdQuery(string id)
        {
            CreatorId = id;
        }
    }
}
