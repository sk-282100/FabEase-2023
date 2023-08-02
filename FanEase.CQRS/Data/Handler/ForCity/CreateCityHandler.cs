using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Commands.ForCity;
using FanEase.Middleware.Data.Commands.ForState;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForCity
{
    internal class CreateCityHandler : IRequestHandler<CityCreateCommand, ResponseModel<bool>>
    {
        private readonly ICityRepository _cityRepository;

        public CreateCityHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<ResponseModel<bool>> Handle(CityCreateCommand request, CancellationToken cancellationToken)
        { 
            City city = new City
            {
                CityName = request.CityName,
                StateId = request.StateId
            };
            bool status = await _cityRepository.AddCity(city);
            return new ResponseModel<bool> { data = status, message = "City Added" };
        }
    }
}
