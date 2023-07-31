using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Commands.ForCampaign;
using FanEase.Middleware.Data.Commands.ForCountry;
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
    public class CountryCreateCommandHandler : IRequestHandler<CountryCreateCommand, ResponseModel<bool>>
    {
        private readonly ICountryRepository _countryRepository;
        public CountryCreateCommandHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public async Task<ResponseModel<bool>> Handle(CountryCreateCommand request, CancellationToken cancellationToken)
        {
            Country country = new Country
            {
                CountryName = request.CountryName,
                
            };

            var rowsAffected = await _countryRepository.CreateCountry(country);
            var response = new ResponseModel<bool> { data = false, message = "failed to create Country" };
            if (rowsAffected > 0)
            {
                response.data = true;
                response.message = "Country created successfully";
            }

            return response;
        }
    }
}
