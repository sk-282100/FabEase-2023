using ExceptionHandling;
using FanEase.Entity.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Queries.ForTemplate
{
    public class GetAllTemplatesByUserQuery : IRequest<ResponseModel<List<TemplateListDTO>>>
    {
       public string UserId { get; set; }

      
    }
}
