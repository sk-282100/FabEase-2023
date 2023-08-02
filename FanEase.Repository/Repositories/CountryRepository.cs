using Dapper;
using FanEase.Entity.Models;
using FanEase.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Repository.Repositories
{
    public class CountryRepository:  BaseRepository,ICountryRepository
    {
        readonly IConfiguration _configuration;

        string connectionString;
        
        public CountryRepository(IConfiguration config, ILogger<BaseRepository> logger) : base(config, logger)
        {
            _configuration = config;
            connectionString = _configuration.GetConnectionString("key");
        }

      

        /// <summary>
        /// Get all Country
        /// </summary>
        /// <returns></returns>

        public async Task<List<Country>> GetAllCountries()
        {
            IEnumerable<Country> countries = await QueryAsync<Country>("GetAllCountry", null, CommandType.StoredProcedure);
            return countries.ToList();
        }
        public async Task<Country> GetCountryById(int CountryId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CountryId", CountryId);

            Country countries = await GetByIdAsync<Country>("GetAllCountryById", parameters, CommandType.StoredProcedure);
            return countries;
        }

        public async Task<int> CreateCountry(Country country)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CountryName",country.CountryName, DbType.String);
            

            int rowsAffected = await ExecuteAsync("CreateCountry", parameters, CommandType.StoredProcedure);
            return rowsAffected;
        }

        public async Task<int> UpdateCountry(Country country)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CountryID", country.CountryId);
            parameters.Add("@CountryName", country.CountryName, DbType.String);
           
            int rowsAffected = await ExecuteAsync("UpdateCountry", parameters, CommandType.StoredProcedure);
            return rowsAffected;
        }

        public async Task<int> DeleteCountry(int countryId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CountryID", countryId);

            int rowsAffected = await ExecuteAsync("DeleteCountry", parameters, CommandType.StoredProcedure);
            return rowsAffected;
        }

        public async Task<Country> CheckCountryNameExists(string CountryName)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CountryName", CountryName);

            Country Country = await GetByNameAsync<Country>("dbo.CheckCountryNameExists", parameters, CommandType.StoredProcedure);
            return Country;
        }

       


    }
}
