using FanEase.Entity.Models;
using FanEase.Repository.Interfaces;


namespace FanEase.Repository.Services
{
    public class CampaignService : ICampaignService
    {
        private readonly ICampaignRepository _campaignRepository;
        public CampaignService(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public async Task<Response?> GetAllCampaignsAsync()
        {
            List<Campaigns> campaigns = await _campaignRepository.GetAllCampaigns();
            Response data = new()
            {
                Result = campaigns,
                Message = "All Campaigns",
                IsSuccess = true,
            };
            return data;
        }

        public async Task<Response?> GetCampaignByIdAsync(int campaignId)
        {
            Campaigns campaign = await _campaignRepository.GetCampaignById(campaignId);


            Response data = new Response
            {
                Result = campaign,
                Message = "Campaign found",
                IsSuccess = true
            };
            return data;
        }

        public async Task<Response> CreateCampaignAsync(Campaigns campaign)
        {
            int rowsAffected = await _campaignRepository.CreateCampaign(campaign);

            Response data = new Response
            {
                Result = rowsAffected > 0 ? campaign : null,
                Message = rowsAffected > 0 ? "Campaign created successfully" : "Failed to create campaign",
                IsSuccess = rowsAffected > 0
            };

            return data;
        }

        public async Task<Response> UpdateCampaignAsync(Campaigns campaign)
        {
            int rowsAffected = await _campaignRepository.UpdateCampaign(campaign);

            Response data = new Response
            {
                Result = rowsAffected > 0 ? campaign : null,
                Message = rowsAffected > 0 ? "Campaign updated successfully" : "Failed to update campaign",
                IsSuccess = rowsAffected > 0
            };

            return data;
        }

        public async Task<Response> DeleteCampaignAsync(int campaignId)
        {
            int rowsAffected = await _campaignRepository.DeleteCampaign(campaignId);

            Response data = new Response
            {
                Result = rowsAffected > 0 ? campaignId : null,
                Message = rowsAffected > 0 ? "Campaign deleted successfully" : "Failed to delete campaign",
                IsSuccess = rowsAffected > 0
            };

            return data;
        }

    }
}
