using ExceptionHandling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForTemplateDetails
{
    public class DeleteTemplateDetailsCommand : IRequest<ResponseModel<bool>>
    {
        public int Id { get; set; }
        public DeleteTemplateDetailsCommand(int id)
        {
            Id = id;   
        }
    }
}
