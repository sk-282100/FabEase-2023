

using Dapper;
using FanEase.Entity.Models;
using FanEase.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

namespace FanEase.Repository.Repositories
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        readonly IConfiguration _configuration;
        string connectionString;

        public AdvertisementRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("Key");
        }
        public async Task<bool> AddAdvertisement(Advertisement advertisement)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync("AddAdvertisementProcedure", advertisement, commandType: CommandType.StoredProcedure);
                if (result > 0)
                    return true;
                return false;
            }
        }

        public async Task<List<AdvertisementListVM>> AdvertisementListScreen()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                List<AdvertisementListVM> advertisements = connection.Query<AdvertisementListVM>("AdvertisementListScreenProcedure", commandType: CommandType.StoredProcedure).ToList();

                return advertisements;
            }
        }


        public async Task<bool> DeleteAdvertisement(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Advertisement advertisement = await GetAdvertisementById(id);
                if (advertisement != null)
                {
                    var result = await connection.ExecuteAsync("DeleteAdvertisementProcedure", new { id }, commandType: CommandType.StoredProcedure);
                    if (result > 0)
                        return true;
                }
                return false;

            }
        }

        public async Task<bool> EditAdvertisement(Advertisement advertisement)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var parameters = new
                {
                    AdvertisementTitle = advertisement.AdvertisementTitle,
                    StartDate = advertisement.StartDate,
                    EndDate = advertisement.EndDate,
                    ContentType = advertisement.ContentType,
                    Description = advertisement.Description,
                    Image = advertisement.Image,
                    AvertisementPlacement = advertisement.AvertisementPlacement,
                    Url = advertisement.Url,
                    AdClicks = advertisement.AdClicks,
                    UserId = advertisement.UserId,
                    AdvertisementId = advertisement.AdvertisementId,

                };
                var result = await connection.ExecuteAsync("EditAdvertisementProcedure", parameters, commandType: CommandType.StoredProcedure);
                if (result > 0)
                    return true;
                return false;

            }
        }

        public async Task<Advertisement> GetAdvertisementById(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Advertisement advertisement =  connection.Query<Advertisement>("GetAdvertisementByIdProcedure", new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return advertisement;
            } 

        }

        public async Task<List<Advertisement>> GetAdvertisementsByUser(string userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                List<Advertisement> advertisements =  connection.Query<Advertisement>("GetAdvertisementsByUserProcedure", new { userId }, commandType: CommandType.StoredProcedure).ToList();

                return advertisements;
            }
        }

        public async Task<List<Advertisement>> GetAllAdvertisements()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                List<Advertisement> advertisements = connection.Query<Advertisement>("GetAllAdvertisementsProcedure", commandType: CommandType.StoredProcedure).ToList();
        
                return advertisements;
            }
        }
    }
}
