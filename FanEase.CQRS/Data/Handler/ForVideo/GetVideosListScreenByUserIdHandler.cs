using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForVideo;
using FanEase.Repository.Interfaces;
using MediatR;

namespace FanEase.Middleware.Data.Handler.ForVideo
{
    public class GetVideosListScreenByUserIdHandler : IRequestHandler<GetVideosListScreenByUserIdQuery, ResponseModel<List<VideoListVm>>>
    {
        readonly IVideoRepository _videoRepository;

        public GetVideosListScreenByUserIdHandler(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public async Task<ResponseModel<List<VideoListVm>>> Handle(GetVideosListScreenByUserIdQuery request, CancellationToken cancellationToken)
        {
            List<VideoListVm> videoList = await _videoRepository.GetVideosListScreenByUserId(request.UserId);
            return new ResponseModel<List<VideoListVm>> { data = videoList, message = "data received" };
        }
    }
}
