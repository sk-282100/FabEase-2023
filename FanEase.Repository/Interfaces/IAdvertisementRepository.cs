﻿using FanEase.Entity.Models;

namespace FanEase.Repository.Interfaces
{
    public interface IAdvertisementRepository
    {
        Task<bool> AddAdvertisement(Advertisement advertisement);
        Task<List<AdvertisementListVM>> AdvertisementListScreen();
        Task<bool> DeleteAdvertisement(int id);
        Task<bool> EditAdvertisement(Advertisement advertisement);
        Task<Advertisement> GetAdvertisementById(int id);
        Task<List<Advertisement>> GetAdvertisementsByUser(string userId);
        Task<List<Advertisement>> GetAllAdvertisements();
    }
}
