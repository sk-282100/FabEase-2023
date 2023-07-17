using ExceptionHandling;
using FanEase.Middleware.Data.Commands.ForTemplate;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForTemplate
{
    public class DeleteTemplateHandler : IRequestHandler<DeleteTemplateCommand, ResponseModel<bool>>
    {
        private readonly ITemplateRepository _templateRepository;

        public DeleteTemplateHandler(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }

        public async Task<ResponseModel<bool>> Handle(DeleteTemplateCommand request, CancellationToken cancellationToken)
        {
            var template = await _templateRepository.GetTemplatesById(request.TemplateId);
            if (template == null)
            {
                return default;
            }
            bool status = await _templateRepository.DeleteTemplates(request.TemplateId);
            return new ResponseModel<bool> { data = status, message = "Template deleted" };
            // throw new NotImplementedException();
        }
    }
}