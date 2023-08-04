

using Dapper;
using FanEase.Entity.Models;
using FanEase.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Text.Json;

namespace FanEase.Repository.Repositories
{
    public class CampaignRepository : BaseRepository, ICampaignRepository
    {

        readonly IConfiguration _configuration;

        string connectionString;
        public CampaignRepository(IConfiguration config, ILogger<BaseRepository> logger) : base(config, logger)
        {
            _configuration = config;
            connectionString = _configuration.GetConnectionString("key");
        }

       

        public async Task<List<Campaigns>> GetAllCampaigns()
        {
            IEnumerable<Campaigns> campaigns = await QueryAsync<Campaigns>("GetAllCampaigns", null, CommandType.StoredProcedure);
            return campaigns.ToList();
        }

        public async Task<Campaigns> GetCampaignById(int campaignId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CampaignId", campaignId);
            Campaigns campaign = await GetByIdAsync<Campaigns>("GetCampaignById", parameters, CommandType.StoredProcedure);
            return campaign;
        }



        public async Task<int> CreateCampaign(Campaigns campaign)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@name", campaign.name, DbType.String);
            parameters.Add("@startDate", campaign.startDate.Date, DbType.Date);
            parameters.Add("@endDate", campaign.endDate.Date, DbType.Date);
            parameters.Add("@engagement", campaign.engagement, DbType.Int32);
            parameters.Add("@userId", campaign.userId, DbType.String);

            int rowsAffected = await ExecuteAsync("CreateCampaign", parameters, CommandType.StoredProcedure);
            return rowsAffected;
        }
        public async Task<int> UpdateCampaign(EditCampaignVm editCampaignVm)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", editCampaignVm.name);
            parameters.Add("@StartDate", editCampaignVm.startDate);
            parameters.Add("@CampaignID", editCampaignVm.campaignId);
            parameters.Add("@EndDate", editCampaignVm.endDate);
            parameters.Add("@Engagement", editCampaignVm.engagement);
            parameters.Add("@UserID", editCampaignVm.userId);
            //parameters.Add("@Advertisement", editCampaignVm.Advertisements);
            // advertismentId
            //advertismenttitle
            int rowsAffected = await ExecuteAsync("UpdateCampaign", parameters, CommandType.StoredProcedure);
            return rowsAffected;
        }

        public async Task<int> DeleteCampaign(int campaignId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CampaignID", campaignId);

            int rowsAffected = await ExecuteAsync("DeleteCampaign", parameters, CommandType.StoredProcedure);
            return rowsAffected;
        }

        public async Task<List<CampaignListScreenVm>> CampaignListScreenByUserId(string userId)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Key")))
            {
                connection.Open();
                List<CampaignListScreenVm> Campagn = connection.Query<CampaignListScreenVm>("CampaignListScreenByUserIdProcedure", new { @userId = userId }, commandType: CommandType.StoredProcedure).ToList();

                return Campagn;
            }
        }


        public async Task<int> LatestAddedCampaign(string userId)
        {
            int campaignId;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                campaignId = connection.ExecuteScalar<int>("LatestAddedCampaignSP", new { @UserId = userId }, commandType: CommandType.StoredProcedure);

            }

            return campaignId;
        }


        public async Task<bool> AssignCampaign(int? campaignId, int? advertisementId)
        {
           
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var result = connection.Execute("AssignAdvertisementSP", new { @CampaignId = campaignId, @AdvertisementId = advertisementId }, commandType: CommandType.StoredProcedure);

                    if (result > 0)
                        return true;
                    return false;
                }
            
        }

    }
}
