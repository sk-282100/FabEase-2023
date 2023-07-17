using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForTemplate;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForTemplate
{
    public class GetAllTemplateHandler : IRequestHandler<GetTemplateListByIdQuery, ResponseModel<Templates>>
    {
        private readonly ITemplateRepository _templateRepository;

        public GetAllTemplateHandler(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }

        public async Task<ResponseModel<Templates>> Handle(GetTemplateListByIdQuery request, CancellationToken cancellationToken)
        {
            Templates template = await _templateRepository.GetTemplatesById(request.TemplateId);
            return new ResponseModel<Templates> { data = template, message = "data received" };
        }
    }
}