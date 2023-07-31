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
    public class CheckCountryNameExistsQuery : IRequest<ResponseModel<Country>>
    {
        public CheckCountryNameExistsQuery(string CountryName)
        {
            this.CountryName = CountryName;
        }

        public string CountryName { get; set; }
    }
}
