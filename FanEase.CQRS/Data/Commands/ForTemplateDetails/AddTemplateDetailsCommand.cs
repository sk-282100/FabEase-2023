
using FanEase.Entity.Models;
using FanEase.HelperClasses.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForTemplateDetails
{
    public class AddTemplateDetailsCommand : IRequest<bool>
    {
        public AddTemplateDetailsCommand(TemplateDetail templateDetail)
        {
            TemplateDetail = templateDetail;
        }

        public TemplateDetail TemplateDetail { get; set; }
    }
}
