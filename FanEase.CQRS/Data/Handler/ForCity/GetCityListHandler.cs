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
    public class GetCityListHandler : IRequestHandler<GetCityListQuery, ResponseModel<List<CityListVM>>>
    {
        private readonly ICityRepository _cityRepository;

        public GetCityListHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<ResponseModel<List<CityListVM>>> Handle(GetCityListQuery request, CancellationToken cancellationToken)
        {
            List<CityListVM> cities = await _cityRepository.GetAllCity();
            return new ResponseModel<List<CityListVM>>() { data = cities, message = "Data Received" };
            //throw new NotImplementedException();
        }
    }
}
