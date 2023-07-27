using ExceptionHandling;
using FanEase.Entity.Models;
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
    public class CreateTemplateHandler : IRequestHandler<CreateTemplateCommand, ResponseModel<bool>>
    {
        private readonly ITemplateRepository _templateRepository;

        public CreateTemplateHandler(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }

        public async Task<ResponseModel<bool>> Handle(CreateTemplateCommand request, CancellationToken cancellationToken)
        {
            Templates temp = request.Templates;
            bool status = await _templateRepository.AddTemplate(temp);
            return new ResponseModel<bool> { data = status, message = "Template Added" };
            //throw new NotImplementedException();
        }
    }
}