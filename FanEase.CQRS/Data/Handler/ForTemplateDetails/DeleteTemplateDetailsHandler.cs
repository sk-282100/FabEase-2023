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
    public class DeleteTemplateDetailsHandler : IRequestHandler<DeleteTemplateDetailsCommand, bool>
    {
        readonly ITemplateDetailsService _templateDetailsService;

        public DeleteTemplateDetailsHandler(ITemplateDetailsService templateDetailsService)
        {
            _templateDetailsService = templateDetailsService;
        }

        public async Task<bool> Handle(DeleteTemplateDetailsCommand request, CancellationToken cancellationToken)
        {
            return await _templateDetailsService.DeleteTemplateDetails(request.Id);
        }
    }
}
