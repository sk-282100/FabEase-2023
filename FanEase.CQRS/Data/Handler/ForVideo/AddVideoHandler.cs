
using ExceptionHandling;
using FanEase.Middleware.Data.Commands.ForVideo;
using FanEase.Repository.Interfaces;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForVideo
{
    public class AddVideoHandler : IRequestHandler<AddVideoCommand,ResponseModel<bool>>
    {
        readonly IVideoRepository _videoRepository;

        public AddVideoHandler(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public async Task<ResponseModel<bool>> Handle(AddVideoCommand request, CancellationToken cancellationToken)
        {
            bool status =await _videoRepository.AddVideo(request.Video);
            return new ResponseModel<bool> { data=status, message="video Added" };
        }
    }
}
