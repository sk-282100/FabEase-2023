using ExceptionHandling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForVideo
{
    public class AssignTemplateCommand : IRequest<ResponseModel<bool>>
    {
        public int? VideoId { get; set; }

        public int? TemplateId { get; set; }

        public AssignTemplateCommand(int? videoId, int? templateId)
        {
            VideoId = videoId; TemplateId = templateId;
        }
    }
}
