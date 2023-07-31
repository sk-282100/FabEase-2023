using ExceptionHandling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForCountry
{
    public class CountryDeleteCommand : IRequest<ResponseModel<bool>>
    {
        public int CountryId { get; set; }
    }
}
