using FanEase.Entity.Models;

namespace FanEase.Repository.Interfaces
{
    public interface ICampaignService
    {
        Task<Response> CreateCampaignAsync(Campaigns campaign);
        Task<Response> DeleteCampaignAsync(int campaignId);
        public Task<Response?> GetAllCampaignsAsync();
        Task<Response> GetCampaignByIdAsync(int campaignId);
        Task<Response> UpdateCampaignAsync(Campaigns campaign);
    }
}
