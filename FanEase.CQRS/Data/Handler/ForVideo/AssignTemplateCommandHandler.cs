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
    public class AssignTemplateCommandHandler : IRequestHandler<AssignTemplateCommand, ResponseModel<bool>>
    {


        readonly IVideoRepository _videoRepository;

        public AssignTemplateCommandHandler(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }

        public async Task<ResponseModel<bool>> Handle(AssignTemplateCommand request, CancellationToken cancellationToken)
        {
            bool status = await _videoRepository.AssignTemplate(request.VideoId, request.TemplateId);
            return new ResponseModel<bool> { data = status, message = "campaign Added" };
        }


    }
}
