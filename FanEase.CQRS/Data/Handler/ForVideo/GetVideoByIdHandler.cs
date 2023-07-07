
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForVideo;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForVideo
{
    public class GetVideoByIdHandler : IRequestHandler<GetVideoByIdQuery, Video>
    {
        readonly IVideoService _videoService;

        public GetVideoByIdHandler(IVideoService videoService)
        {
            _videoService = videoService;
        }
        public async Task<Video> Handle(GetVideoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _videoService.GetVideoById(request.Id);
        }
    }
}
