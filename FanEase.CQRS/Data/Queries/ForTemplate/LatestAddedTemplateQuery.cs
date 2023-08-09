using ExceptionHandling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Queries.ForTemplate
{
    public class LatestAddedTemplateQuery : IRequest<ResponseModel<int>>
    {
        public string UserId { get; set; }

        public LatestAddedTemplateQuery(string userId)
        {
            UserId = userId;
        }
    }
}