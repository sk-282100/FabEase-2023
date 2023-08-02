using Dapper;
using FanEase.Entity.Models;
using FanEase.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Repository.Repositories
{
    public class CityRepository : ICityRepository
    {
        string connectionString;

        private readonly IConfiguration _configuration;

        public CityRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("Key");
        }

        public async Task<List<CityListVM>> GetAllCity()
        {
            List<CityListVM> states = new List<CityListVM>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                states = connection.Query<CityListVM>("GetAllCityProcedure", commandType: CommandType.StoredProcedure).ToList();

            }
            return states;
        }

        public async Task<bool> AddCity(City city)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var result = connection.Execute("AddCityProcedure", new { @CityName = city.CityName, @StateId = city.StateId }, commandType: CommandType.StoredProcedure);

                if (result > 0)
                    return true;
                return false;
            }
        }

        public async Task<City> GetCityById(int id)
        {
            City states = new City();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                states = connection.Query<City>("GetCityByIdProcedure", new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return states;
        }

        public async Task<bool> DeleteCity(int id)
        {

            City city = new City();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                city = connection.Query<City>("GetCityByIdProcedure", new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                if (city != null)
                {
                    var result = connection.Execute("DeleteCityProcedure", new { id }, commandType: CommandType.StoredProcedure);
                    if (result > 0)
                        return true;
                }
                return false;
            }

        }

        public async Task<bool> UpdateCity(City city)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Execute("EditCityProcedure", city, commandType: CommandType.StoredProcedure);
                if (result > 0)
                    return true;
                return false;
            }
        }
    }
}