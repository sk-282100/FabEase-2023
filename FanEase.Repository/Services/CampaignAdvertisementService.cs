using FanEase.Entity.Models;
using FanEase.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Repository.Services
{
    public class CampaignAdvertisementService : ICampaignAdvertisementService
    {
        private readonly ICampaignAdvertisementRepository _campaignAdvertisementRepository;
        public CampaignAdvertisementService(ICampaignAdvertisementRepository campaignAdvertisementRepository)
        {
            _campaignAdvertisementRepository = campaignAdvertisementRepository;
        }
        public async Task<Response> CreateCampaignAdvertisementAsync(Campaign_Advertisement Advertisement)
        {
            int rowsAffected = await _campaignAdvertisementRepository.CreateCampaignAdvertisement(Advertisement);

            Response data = new Response
            {
                Result = rowsAffected > 0 ? Advertisement : null,
                Message = rowsAffected > 0 ? "Campaign created successfully" : "Failed to create campaign",
                IsSuccess = rowsAffected > 0
            };

            return data;
        }

        public async Task<Response> DeleteCampaignAdvertisementAsync(int Id)
        {
            int rowsAffected = await _campaignAdvertisementRepository.DeleteCampaignAdvertisement(Id);
            if (rowsAffected < 0)
            {
                return new Response() { IsSuccess = false, Result = Id, Message = "Failed to delete campaign" };
            }
            return new Response() { IsSuccess = true, Result = Id, Message = "CampaignAdvertisement deleted successfully" };
        }

        public async Task<Response?> GetAllCampaignAdvertisementsAsync()
        {
            List<Campaign_Advertisement> campaigns = await _campaignAdvertisementRepository.GetAllCampaignAdvertisements();
            Response data = new()
            {
                Result = campaigns,
                Message = "All Campaigns",
                IsSuccess = true,
            };
            return data;
        }

        public async Task<Response> GetCampaignAdvertisementByIdAsync(int Id)
        {
            Campaign_Advertisement campaign = await _campaignAdvertisementRepository.GetCampaignAdvertisementById(Id);


            Response data = new Response
            {
                Result = campaign,
                Message = "CampaignAdvertisement found",
                IsSuccess = true
            };
            return data;
        }

        public async Task<Response> UpdateCampaignAdvertisementAsync(Campaign_Advertisement Advertisement)
        {
            int rowsAffected = await _campaignAdvertisementRepository.UpdateCampaignAdvertisement(Advertisement);

            Response data = new Response
            {
                Result = rowsAffected > 0 ? Advertisement : null,
                Message = rowsAffected > 0 ? "CampaignAdvertisement Updated successfully" : "Failed to create campaign",
                IsSuccess = rowsAffected > 0
            };

            return data;
        }
    }
}
