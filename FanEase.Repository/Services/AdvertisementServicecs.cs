

using FanEase.Entity.Models;
using FanEase.Repository.Interfaces;

namespace FanEase.Repository.Services
{
    public class AdvertisementServicecs : IAdvertisementService
    {
        readonly IAdvertisementRepository _advertisementRepository;

        public AdvertisementServicecs(IAdvertisementRepository advertisementRepository)
        {
            _advertisementRepository = advertisementRepository;
        }
        public async Task<bool> AddAdvertisement(Advertisement advertisement)
        {
            return await _advertisementRepository.AddAdvertisement(advertisement);
        }

        public async Task<bool> DeleteAdvertisement(int id)
        {
            return await _advertisementRepository.DeleteAdvertisement(id);
        }

        public async Task<bool> EditAdvertisement(Advertisement advertisement)
        {
            return await _advertisementRepository.EditAdvertisement(advertisement);
        }

        public async Task<Advertisement> GetAdvertisementById(int id)
        {
            return await _advertisementRepository.GetAdvertisementById(id);
        }

        public async Task<List<Advertisement>> GetAdvertisementsByUser(string userId)
        {
            return await _advertisementRepository.GetAdvertisementsByUser(userId);
        }

        public async Task<List<Advertisement>> GetAllAdvertisements()
        {
            return await _advertisementRepository.GetAllAdvertisements();
        }
    }
}
