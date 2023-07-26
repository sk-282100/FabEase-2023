using Dapper;
using FanEase.Entity.Models;
using FanEase.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Repository.Repositories
{
    public class CampaignAdvertisementRepository : BaseRepository, ICampaignAdvertisementRepository
    {
        public CampaignAdvertisementRepository(IConfiguration config, ILogger<BaseRepository> logger) : base(config, logger)
        {
        }

        public async Task<int> CreateCampaignAdvertisement(Campaign_Advertisement Advertisement)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@campaignId", Advertisement.campaignId);
            parameters.Add("@advertisementId", Advertisement.advertisementId);

            int rowsAffected = await ExecuteAsync("CreateCampaignAdvertisement", parameters, CommandType.StoredProcedure);
            return rowsAffected;
        }

        public async Task<int> DeleteCampaignAdvertisement(int campaignId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CampaignId", campaignId);

            int rowsAffected = await ExecuteAsync("DeleteCampaignAdvertisementByCampaignId", parameters, CommandType.StoredProcedure);
            return rowsAffected;
        }

        public async Task<List<Campaign_Advertisement>> GetAllCampaignAdvertisements()
        {
            IEnumerable<Campaign_Advertisement> campaigns = await QueryAsync<Campaign_Advertisement>("GetAllCampaignAdvertisements", null, CommandType.StoredProcedure);
            return campaigns.ToList();
        }

        public async Task<Campaign_Advertisement> GetCampaignAdvertisementById(int campaignId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@CampaignId", campaignId);

            Campaign_Advertisement campaign = await GetByIdAsync<Campaign_Advertisement>("GetCampaignAdvertisementById", parameters, CommandType.StoredProcedure);
            return campaign;
        }

        public async Task<int> UpdateCampaignAdvertisement(Campaign_Advertisement Advertisement)
        {
            DynamicParameters parameters = new DynamicParameters();
            
            parameters.Add("@campaignId", Advertisement.campaignId);
            parameters.Add("@advertisementId", Advertisement.advertisementId);


            int rowsAffected = await ExecuteAsync("UpdateCampaignAdvertisement", parameters, CommandType.StoredProcedure);
            return rowsAffected;
        }

    }
}
