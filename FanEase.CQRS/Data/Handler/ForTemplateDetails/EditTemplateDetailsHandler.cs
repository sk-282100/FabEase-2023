using FanEase.Middleware.Data.Commands.ForTemplateDetails;
using FanEase.Repository.Interfaces;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForTemplateDetails
{
    public class EditTemplateDetailsHandler : IRequestHandler<EditTemplateDetailsCommand,bool>
    {
        readonly ITemplateDetailsService _templateDetailsService;

        public EditTemplateDetailsHandler(ITemplateDetailsService templateDetailsService)
        {
            _templateDetailsService = templateDetailsService;
        }

        public async Task<bool> Handle(EditTemplateDetailsCommand request, CancellationToken cancellationToken)
        {
            return await _templateDetailsService.EditTemplateDetails(request.TemplateDetail);
        }
    }
}
