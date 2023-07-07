
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
    public class EditVideoHandler : IRequestHandler<EditVideoCommand,bool>
    {
        readonly IVideoService _videoService;

        public EditVideoHandler(IVideoService videoService)
        {
            _videoService = videoService;
        }

        public async Task<bool> Handle(EditVideoCommand request, CancellationToken cancellationToken)
        {
            return await _videoService.EditVideo(request.Video);
        }
    }
}
