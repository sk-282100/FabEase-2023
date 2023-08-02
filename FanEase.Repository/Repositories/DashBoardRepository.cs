using Dapper;
using FanEase.Entity.Models;
using FanEase.Repository.Interfaces;
using Microsoft.AspNetCore.Routing;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace FanEase.Repository.Repositories
{
    public class DashBoardRepository : IDashBoardRepository
    {

        readonly IConfiguration _configuration;
        string connectionString;
        public DashBoardRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("Key");
        }

        public async Task<AdminDashboardDTO> GetAdminDashBoard()
        {

            AdminDashboardDTO dashboardDTO = new AdminDashboardDTO();
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                List<Video> videos = connection.Query<Video>("GetAllVideosProcedure", commandType: CommandType.StoredProcedure).ToList();
                dashboardDTO.Views = 0;
                foreach (Video video in videos)
                {
                    dashboardDTO.Views= dashboardDTO.Views+video.Views;
                    
                }

                dashboardDTO.VideoCount=videos.Count;
                dashboardDTO.Videos=(from v in videos orderby v.Views descending select v).Take(5).ToList();
                
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                List<Campaigns> campaigns = connection.Query<Campaigns>("GetAllCampaigns", commandType: CommandType.StoredProcedure).ToList();

                dashboardDTO.Campaigns = (from c in campaigns orderby c.engagement descending select c).Take(5).ToList();
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                dashboardDTO.CreatorCount = connection.Query<User>("ContenetCreatorListSP", commandType: CommandType.StoredProcedure).ToList().Count;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                List<AdvertisementListVM> advertisements = connection.Query<AdvertisementListVM>("AdvertisementListScreenProcedure", commandType: CommandType.StoredProcedure).ToList();
                dashboardDTO.AdvertisementClicks = advertisements.Sum(item => item.AdClicks);
                dashboardDTO.AdvertisementCount = advertisements.Count;
            }

            



            return dashboardDTO;

        }
    }
}
