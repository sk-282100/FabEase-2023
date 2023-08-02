using ExceptionHandling;
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
    public class UpdateCityHandler : IRequestHandler<CityUpdateCommand, ResponseModel<bool>>
    {
        private readonly ICityRepository _cityRepository;

        public UpdateCityHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<ResponseModel<bool>> Handle(CityUpdateCommand request, CancellationToken cancellationToken)
        {
            bool status = await _cityRepository.UpdateCity(request.City);
            return new ResponseModel<bool> { data = status, message = "City Edited" };
        }
    }
}