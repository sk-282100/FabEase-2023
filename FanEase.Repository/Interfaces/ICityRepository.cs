using FanEase.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Repository.Interfaces
{
    public interface ICityRepository
    {
        Task<bool> AddCity(City city);
        Task<List<CityListVM>> GetAllCity();
        Task<City> GetCityById(int id);
        Task<bool> DeleteCity(int id);
        Task<bool> UpdateCity(City city);
    }
}
