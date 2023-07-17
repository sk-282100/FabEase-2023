
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
    public class GetAllVideosHandler : IRequestHandler<GetAllVideosQuery, ResponseModel<List<Video>>>
    {
        readonly IVideoRepository _videoRepository;

        public GetAllVideosHandler(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }
        public async Task<ResponseModel<List<Video>>> Handle(GetAllVideosQuery request, CancellationToken cancellationToken)
        {
            List<Video> videos = await _videoRepository.GetAllVideos();
            return new ResponseModel<List<Video>>() { data=videos, message="data received"};
        }
    }
}
