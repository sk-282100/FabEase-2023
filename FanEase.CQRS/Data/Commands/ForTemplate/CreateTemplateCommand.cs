using ExceptionHandling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForTemplate
{
    public class CreateTemplateCommand : IRequest<ResponseModel<bool>>
    {
        public CreateTemplateCommand(int templateDetailsId, string userId)
        {
            TemplateDetailsId = templateDetailsId;
            UserId = userId;
        }

        public int TemplateDetailsId { get; set; }
        public string UserId { get; set; }
    }
}
