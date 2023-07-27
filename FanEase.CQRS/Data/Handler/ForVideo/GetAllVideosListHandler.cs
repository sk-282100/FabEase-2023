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
    public class GetAllVideosListHandler : IRequestHandler<GetAllVideosListQuery, ResponseModel<List<VideoListVm>>>
    {
        readonly IVideoRepository _videoRepository;

        public GetAllVideosListHandler(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }
        public async Task<ResponseModel<List<VideoListVm>>> Handle(GetAllVideosListQuery request, CancellationToken cancellationToken)
        {
            List<VideoListVm> videosList = await _videoRepository.GetAllVideosList();
            return new ResponseModel<List<VideoListVm>>() { data = videosList, message = "data received" };
        }
    }
}

