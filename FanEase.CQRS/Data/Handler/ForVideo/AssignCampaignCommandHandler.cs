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
    public class AssignCampaignCommandHandler : IRequestHandler<AssignCampaignCommand,ResponseModel<bool>>
    {
        
        
            readonly IVideoRepository _videoRepository;

            public AssignCampaignCommandHandler(IVideoRepository videoRepository)
            {
                _videoRepository = videoRepository;
            }

            public async Task<ResponseModel<bool>> Handle(AssignCampaignCommand request, CancellationToken cancellationToken)
            {
                bool status = await _videoRepository.AssignCampaign(request.VideoId, request.CampaignId);
                return new ResponseModel<bool> { data = status, message = "campaign Added" };
            }
        

    }
}
