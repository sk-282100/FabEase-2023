using ExceptionHandling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForCountry
{
    public class CountryCreateCommand : IRequest<ResponseModel<bool>>
    {
        public string CountryName { get; set; }
    }
}
