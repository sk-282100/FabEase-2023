using ExceptionHandling;
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
    public class CountryDeleteCommandHandler : IRequestHandler<CountryDeleteCommand, ResponseModel<bool>>
    {
        private readonly ICountryRepository _countryRepository;
        public CountryDeleteCommandHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public async Task<ResponseModel<bool>> Handle(CountryDeleteCommand request, CancellationToken cancellationToken)
        {
            var Country = await _countryRepository.GetCountryById(request.CountryId);
            if (Country == null)
                return default;
            int rowsAffected = await _countryRepository.DeleteCountry(request.CountryId);


            var response = new ResponseModel<bool> { data = false, message = " Delete Country" };
            if (rowsAffected > 0)
            {
                response.data = true;
                response.message = "Country Deleted successfully";
            }

            return response;
        }
    }
}
