using ExceptionHandling;
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
    public class LatestAddedVideoQueryHandler : IRequestHandler<LatestAddedVideoQuery,ResponseModel<int>>
    {
        readonly IVideoRepository _videoRepository;

        public LatestAddedVideoQueryHandler(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }
        public async Task<ResponseModel<int>> Handle(LatestAddedVideoQuery request, CancellationToken cancellationToken)
        {
            int VideoId = await _videoRepository.LatestAddedVideo(request.UserId);
            return new ResponseModel<int> { data = VideoId, message = "data received" };
        }
    }
}
