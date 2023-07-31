using ExceptionHandling;
using FanEase.Entity.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Queries.ForCountry
{
    public class GetAllCountryIdQuery : IRequest<ResponseModel<Country>>
    {
        public GetAllCountryIdQuery(int countryId)
        {
           this.countryId= countryId;
        }

        public int countryId { get; set; }
    }
}
