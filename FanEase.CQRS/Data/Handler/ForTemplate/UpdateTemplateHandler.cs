using ExceptionHandling;
using FanEase.Middleware.Data.Commands.ForTemplate;
using FanEase.Repository.Interfaces;
using FanEase.Repository.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForTemplate
{
    public class UpdateTemplateHandler : IRequestHandler<UpdateTemplateCommand, ResponseModel<bool>>
    {
        private readonly ITemplateRepository _templateRepository;

        public UpdateTemplateHandler(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }

        public async Task<ResponseModel<bool>> Handle(UpdateTemplateCommand request, CancellationToken cancellationToken)
        {
            //var template = await _templateRepository.GetTemplatesById(request.TemplateId);
            //if (template == null)
            //{
            //    return default;
            //}

            //template.TemplateDetailsId = request.TemplateId;
            //template.UserId = request.UserId;

            bool status = await _templateRepository.UpdateTemplates(request.Templates);
            return new ResponseModel<bool> { data = status, message = "Template Edited" };
            // throw new NotImplementedException();
        }
    }
}
