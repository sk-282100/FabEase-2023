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
    public class GetAllCountryIdQueryHandler : IRequestHandler<GetAllCountryIdQuery, ResponseModel<Country>>
    {
        private readonly ICountryRepository _countryRepository;
        public GetAllCountryIdQueryHandler(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public async Task<ResponseModel<Country>> Handle(GetAllCountryIdQuery request, CancellationToken cancellationToken)
        {

            Country countries = await _countryRepository.GetCountryById(request.countryId);



            return new ResponseModel<Country> { data = countries, message = "Country Received" };
        }
    }
}
