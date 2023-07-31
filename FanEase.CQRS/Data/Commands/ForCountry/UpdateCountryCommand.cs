using ExceptionHandling;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Commands.ForCountry
{
    public class UpdateCountryCommand : IRequest<ResponseModel<bool>>
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
