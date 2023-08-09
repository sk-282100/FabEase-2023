using ExceptionHandling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Queries.ForTemplateDetails
{
    public class LatestAddedTemplateDetailsQuery : IRequest<ResponseModel<int>>
    {
        public string UserId { get; set; }

        public LatestAddedTemplateDetailsQuery(string userId)
        {
            UserId = userId;
        }
    }
}