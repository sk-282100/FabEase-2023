

using Dapper;
using FanEase.Entity.Models;
using FanEase.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;

namespace FanEase.Repository.Repositories
{
    public class CampaignRepository : BaseRepository, ICampaignRepository
    {



        public CampaignRepository(IConfiguration config, ILogger<BaseRepository> logger) : base(config, logger)
        {

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
            parameters.Add("@userId", campaign.userId, DbType.Int32);

            int rowsAffected = await ExecuteAsync("CreateCampaign", parameters, CommandType.StoredProcedure);
            return rowsAffected;
        }
        public async Task<int> UpdateCampaign(Campaigns campaign)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", campaign.name);
            parameters.Add("@StartDate", campaign.startDate);
            parameters.Add("@CampaignID", campaign.campaignId);
            parameters.Add("@EndDate", campaign.endDate);
            parameters.Add("@Engagement", campaign.engagement);
            parameters.Add("@UserID", campaign.userId);

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

    }
}
