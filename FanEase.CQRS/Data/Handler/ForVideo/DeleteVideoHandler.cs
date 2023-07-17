
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
    public class DeleteVideoHandler : IRequestHandler<DeleteVideoCommand,ResponseModel<bool>>
    {
        readonly IVideoRepository _videoRepository;

        public DeleteVideoHandler(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public async Task<ResponseModel<bool>> Handle(DeleteVideoCommand request, CancellationToken cancellationToken)
        {
            bool status =  await _videoRepository.DeleteVideo(request.Id);
            return new ResponseModel<bool> { data = status, message = "video deleted" };
        }
    }
}
