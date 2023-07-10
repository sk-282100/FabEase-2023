
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
    public class EditVideoHandler : IRequestHandler<EditVideoCommand,ResponseModel<bool>>
    {
        readonly IVideoRepository _videoRepository;

        public EditVideoHandler(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public async Task<ResponseModel<bool>> Handle(EditVideoCommand request, CancellationToken cancellationToken)
        {
            bool status =  await _videoRepository.EditVideo(request.Video);
            return new ResponseModel<bool> { data = status, message = "video Added" };
        }
    }
}
