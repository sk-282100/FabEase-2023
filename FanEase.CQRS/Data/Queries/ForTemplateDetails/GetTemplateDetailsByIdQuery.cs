
using FanEase.Entity.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Queries.ForTemplateDetails
{
    public class GetTemplateDetailsByIdQuery : IRequest<TemplateDetail>
    {
        public int Id { get; set; }

        public GetTemplateDetailsByIdQuery(int id)
        {
            Id =id;
        }
    }
}
