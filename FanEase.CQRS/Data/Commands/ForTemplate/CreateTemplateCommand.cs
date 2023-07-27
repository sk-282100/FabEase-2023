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
    public class CreateTemplateCommand : IRequest<ResponseModel<bool>>
    {
        public CreateTemplateCommand(Templates template)
        {
            Templates = template;
        }

        public Templates Templates { get; set; }
    }
}
