
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
    public class AddVideoHandler : IRequestHandler<AddVideoCommand,bool>
    {
        readonly IVideoService _videoService;

        public AddVideoHandler(IVideoService videoService)
        {
            _videoService = videoService;
        }

        public async Task<bool> Handle(AddVideoCommand request, CancellationToken cancellationToken)
        {
            return await _videoService.AddVideo(request.Video);
        }
    }
}
