
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
            TemplateDetailId = templateDetail.TemplateDetailId;
            ThumbnilImage = templateDetail.ThumbnilImage;
            TemplateTitle = templateDetail.TemplateTitle;
            TemplateType = templateDetail.TemplateType;
        }

        public int TemplateDetailId { get; set; }

        public string ThumbnilImage { get; set; }

        public string TemplateTitle { get; set; }

        public string TemplateType { get; set; }
    }
}
