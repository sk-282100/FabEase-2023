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
    public class GetAllTemplatesByUserQueryHandler : IRequestHandler<GetAllTemplatesByUserQuery, ResponseModel<List<TemplateListDTO>>>
    {
        readonly ITemplateRepository _templateRepository;

        public GetAllTemplatesByUserQueryHandler(ITemplateRepository templateRepository)
        {
            _templateRepository = templateRepository;
        }

        public async Task<ResponseModel<List<TemplateListDTO>>> Handle(GetAllTemplatesByUserQuery request, CancellationToken cancellationToken)
        {
            List<TemplateListDTO> templates = await _templateRepository.GetAllTemplatesByUser(request.UserId);

            return new ResponseModel<List<TemplateListDTO>>(){ data=templates,message="data received" };
        }
    }

}
