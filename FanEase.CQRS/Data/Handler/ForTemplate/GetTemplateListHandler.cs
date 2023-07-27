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
    public class GetTemplateListHandler : IRequestHandler<GetTemplateListQuery, ResponseModel<List<TemplateListDTO>>>
    {
        private readonly ITemplateRepository _templateRepository;

        public GetTemplateListHandler(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }

        public async Task<ResponseModel<List<TemplateListDTO>>> Handle(GetTemplateListQuery request, CancellationToken cancellationToken)
        {
            List<TemplateListDTO> templates = await _templateRepository.GetAllTemplatesAsync();
            return new ResponseModel<List<TemplateListDTO>>() { data = templates, message = "data received" };

            //throw new NotImplementedException(); 
        }
    }
}
