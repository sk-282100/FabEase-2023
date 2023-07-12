using FanEase.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Repository.Interfaces
{
    public interface ICampaignAdvertisementService
    {
        Task<Response> CreateCampaignAdvertisementAsync(Campaign_Advertisement Advertisement);
        Task<Response> DeleteCampaignAdvertisementAsync(int Id);
        public Task<Response?> GetAllCampaignAdvertisementsAsync();
        Task<Response> GetCampaignAdvertisementByIdAsync(int Id);
        Task<Response> UpdateCampaignAdvertisementAsync(Campaign_Advertisement Advertisement);
    }
}
