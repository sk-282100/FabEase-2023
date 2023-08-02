using ExceptionHandling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForCity
{
    public class CityeDeleteCommand : IRequest<ResponseModel<bool>>
    {
        public int CityId { get; set; }
    
    }
}
