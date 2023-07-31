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
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, ResponseModel<bool>>
    {
        private readonly ICountryRepository _countryRepository;
        public UpdateCountryCommandHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public async Task<ResponseModel<bool>> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            Country country = new Country
            {
               CountryId = request.CountryId,
               CountryName = request.CountryName
            };

            var rowsAffected = await _countryRepository.UpdateCountry(country);
            var response = new ResponseModel<bool> { data = false, message = " Update Country" };
            if (rowsAffected > 0)
            {
                response.data = true;
                response.message = "Country Updated successfully";
            }

            return response;
        }
    }
}
