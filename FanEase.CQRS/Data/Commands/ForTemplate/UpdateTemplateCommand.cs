using ExceptionHandling;
using FanEase.Entity.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForTemplate
{
    public class UpdateTemplateCommand : IRequest<ResponseModel<bool>>
    {
        public UpdateTemplateCommand(Templates templates)
        {
            Templates = templates;
        }

       public Templates Templates { get; set; }
    }
}