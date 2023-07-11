
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
    public class GetVideoByIdQuery : IRequest<ResponseModel<Video>>
    {
        public int Id { get; set; }

        public GetVideoByIdQuery(int id)
        {
            Id = id;
        }
    }
}
