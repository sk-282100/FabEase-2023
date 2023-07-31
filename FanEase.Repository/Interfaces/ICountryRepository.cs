using FanEase.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Repository.Interfaces
{
    public interface ICountryRepository
    {
        Task<int> CreateCountry(Country country);
        Task<int> DeleteCountry(int countryId);
        public Task<List<Country>> GetAllCountries();
        Task<Country> GetCountryById(int countryId);
        Task<int> UpdateCountry(Country country);
        Task<Country> CheckCountryNameExists(string CountryName);
        
    }
}
