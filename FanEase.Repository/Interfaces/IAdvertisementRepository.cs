using FanEase.Entity.Models;

namespace FanEase.Repository.Interfaces
{
    public interface IAdvertisementRepository
    {
        Task<List<AdvertisementListVM>> AdvertisementListScreen();
        Task<bool> AddAdvertisement(Advertisement advertisement);
       
        Task<bool> DeleteAdvertisement(int id);
        Task<bool> EditAdvertisement(Advertisement advertisement);
        Task<Advertisement> GetAdvertisementById(int id);
        Task<List<Advertisement>> GetAdvertisementsByUser(string userId);
        Task<List<Advertisement>> GetAllAdvertisements();
        Task<List<AdvertisementListVM>> AdvertisementListScreenByUserId(string userId);
        Task<List<AdvertisemenetForTemp>> GetAdvertisementsByCampaign(int campaignId);
    }
}
