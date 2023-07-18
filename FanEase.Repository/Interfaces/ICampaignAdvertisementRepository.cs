using FanEase.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Repository.Interfaces
{
    public interface ICampaignAdvertisementRepository
    {
        Task<int> CreateCampaignAdvertisement(Campaign_Advertisement Advertisement);
        Task<int> DeleteCampaignAdvertisement(int Id);
        public Task<List<Campaign_Advertisement>> GetAllCampaignAdvertisements();
        Task<Campaign_Advertisement> GetCampaignAdvertisementById(int Id);
        Task<int> UpdateCampaignAdvertisement(Campaign_Advertisement Advertisement);
    }
}
