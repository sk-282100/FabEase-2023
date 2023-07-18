using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForVideo;
using FanEase.Repository.Interfaces;
using MediatR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForVideo
{
    public class GetVideosByUserIdQueryHandler : IRequestHandler<GetVideosByUserIdQuery, ResponseModel<List<Video>>>
    {
        readonly IVideoRepository _videoRepository;

        public GetVideosByUserIdQueryHandler(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }
        public async Task<ResponseModel<List<Video>>> Handle(GetVideosByUserIdQuery request, CancellationToken cancellationToken)
        {
            List<Video> video = await _videoRepository.GetVideosByUserId(request.UserId);
            return new ResponseModel<List<Video>>()
            {
                data = video,
                message = "data received"
            };
        }
    }
}
