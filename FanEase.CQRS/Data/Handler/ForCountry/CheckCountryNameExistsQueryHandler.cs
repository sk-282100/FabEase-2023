using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForCountry;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForCountry
{
    public class CheckCountryNameExistsQueryHandler : IRequestHandler<CheckCountryNameExistsQuery, ResponseModel<Country>>
    {
        private readonly ICountryRepository _countryRepository;
        public CheckCountryNameExistsQueryHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public async Task<ResponseModel<Country>> Handle(CheckCountryNameExistsQuery request, CancellationToken cancellationToken)
        {
            Country countries = await _countryRepository.CheckCountryNameExists(request.CountryName);

            if (countries==null)
            {
                return new ResponseModel<Country> { Succeed = false, data = countries, message = "Country Not Exist CheckCountryName" };
            }

            return new ResponseModel<Country> { data = countries, message = "Country All Ready Exist CheckCountryName" };
        }
    }
}
