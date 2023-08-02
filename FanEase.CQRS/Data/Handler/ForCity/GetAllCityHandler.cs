using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Middleware.Data.Queries.ForCity;
using FanEase.Middleware.Data.Queries.ForState;
using FanEase.Repository.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Middleware.Data.Handler.ForCity
{
    public class GetAllCityHandler : IRequestHandler<GetCityListByIdQuery, ResponseModel<City>>
    {
        private readonly ICityRepository _cityRepository;

        public GetAllCityHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<ResponseModel<City>> Handle(GetCityListByIdQuery request, CancellationToken cancellationToken)
        {
            City city = await _cityRepository.GetCityById(request.CityId);
            return new ResponseModel<City>() { data = city, message = "Data Received" };
            
        }
    }
}
