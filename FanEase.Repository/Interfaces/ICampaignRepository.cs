using FanEase.Entity.Models;

namespace FanEase.Repository.Interfaces
{
    public interface ICampaignRepository
    {
        Task<int> CreateCampaign(Campaigns campaign);
        Task<int> DeleteCampaign(int campaignId);
        public Task<List<Campaigns>> GetAllCampaigns();
        Task<Campaigns> GetCampaignById(int campaignId);
        Task<int> UpdateCampaign(Campaigns campaign);
        Task<List<CampaignListScreenVm>> CampaignListScreenByUserId(string userId);
    }
}
