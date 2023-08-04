using FanEase.Entity.Models;

namespace FanEase.Repository.Interfaces
{
    public interface ICampaignRepository
    {
        Task<int> CreateCampaign(Campaigns campaign);
        Task<int> DeleteCampaign(int campaignId);
        public Task<List<Campaigns>> GetAllCampaigns();
        Task<Campaigns> GetCampaignById(int campaignId);
        Task<int> UpdateCampaign(EditCampaignVm editCampaignVm);
        Task<List<CampaignListScreenVm>> CampaignListScreenByUserId(string userId);
        Task<int> LatestAddedCampaign(string userId);

        Task<bool> AssignCampaign(int? campaignId, int? advertisementId);

        //Task<EditCampaignVm> EditCampaignAd(int campaignId);

    }
}
