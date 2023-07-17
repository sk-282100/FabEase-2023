using ExceptionHandling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForTemplate
{
    public class DeleteTemplateCommand : IRequest<ResponseModel<bool>>
    {
        public int TemplateId { get; set; }
    }
}