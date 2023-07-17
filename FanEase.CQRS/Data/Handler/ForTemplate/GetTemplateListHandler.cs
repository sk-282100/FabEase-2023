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
    public class GetTemplateListHandler : IRequestHandler<GetTemplateListQuery, ResponseModel<List<Templates>>>
    {
        private readonly ITemplateRepository _templateRepository;

        public GetTemplateListHandler(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }

        public async Task<ResponseModel<List<Templates>>> Handle(GetTemplateListQuery request, CancellationToken cancellationToken)
        {
            List<Templates> templates = await _templateRepository.GetAllTemplatesAsync();
            return new ResponseModel<List<Templates>>() { data = templates, message = "data received" };

            //throw new NotImplementedException(); 
        }
    }
}
