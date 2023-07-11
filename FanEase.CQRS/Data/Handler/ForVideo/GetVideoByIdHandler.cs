
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
    public class GetVideoByIdHandler : IRequestHandler<GetVideoByIdQuery, ResponseModel<Video>>
    {
        readonly IVideoRepository _videoRepository;

        public GetVideoByIdHandler(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }
        public async Task<ResponseModel<Video>> Handle(GetVideoByIdQuery request, CancellationToken cancellationToken)
        {
           Video video = await _videoRepository.GetVideoById(request.Id);
            return new ResponseModel<Video> { data=video, message="data received" };
        }
    }
}
