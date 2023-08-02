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
    public class DeleteCityHandler : IRequestHandler<CityeDeleteCommand, ResponseModel<bool>>
    {
        private readonly ICityRepository _cityRepository;

        public DeleteCityHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<ResponseModel<bool>> Handle(CityeDeleteCommand request, CancellationToken cancellationToken)
        {
            var city = await _cityRepository.GetCityById(request.CityId);
            if (city == null)
            {
                return default;
            }
            bool status = await _cityRepository.DeleteCity(request.CityId);
            return new ResponseModel<bool> { data = status, message = "City deleted" };
        }
    }
}
