using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForCampaign;
using FanEase.Middleware.Data.Queries.ForCountry;
using FanEase.Repository.Interfaces;
using FanEase.Repository.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForCountry
{
    public class GetAllCountrysQueryHandler : IRequestHandler<GetAllCountrysQuery, ResponseModel<List<Country>>>
    {
        private readonly ICountryRepository _countryRepository;
        public GetAllCountrysQueryHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public async Task<ResponseModel<List<Country>>> Handle(GetAllCountrysQuery request, CancellationToken cancellationToken)
        {
            List<Country> countries = await _countryRepository.GetAllCountries();

            return new ResponseModel<List<Country>> { data = countries, message = "Country Received" };
        }
    }
}
