using FanEase.Middleware.Data.Commands.ForTemplateDetails;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForTemplateDetails
{
    public class AddTemplateDetailsHandler : IRequestHandler<AddTemplateDetailsCommand, bool>
    {
        readonly ITemplateDetailsService _templateDetailsService;

        public AddTemplateDetailsHandler(ITemplateDetailsService templateDetailsService)
        {
            _templateDetailsService = templateDetailsService;
        }
        public async Task<bool> Handle(AddTemplateDetailsCommand request, CancellationToken cancellationToken)
        {
            return await _templateDetailsService.AddTemplateDetails(request.TemplateDetail);
        }
    }
}
