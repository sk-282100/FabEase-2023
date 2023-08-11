using FanEase.Entity.Models;

namespace FanEase.Repository.Interfaces
{
    public interface ICampaignRepository
    {
        Task<int> CreateCampaign(Campaigns campaign);
        Task<int> DeleteCampaign(int campaignId);
        public Task<List<Campaigns>> GetAllCampaigns();
        Task<MainCampaign> GetCampaignById(int campaignId);
        Task<int> UpdateCampaign(EditCampaignVm editCampaignVm);
        Task<List<CampaignListScreenVm>> CampaignListScreenByUserId(string userId);
        Task<int> LatestAddedCampaign(string userId);
        Task<Campaigns> GetCampaignDetailsById(int campaignId);
        //Task<EditCampaignVm> EditCampaignAd(int campaignId);
    }
}
