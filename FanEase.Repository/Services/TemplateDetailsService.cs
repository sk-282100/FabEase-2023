

using FanEase.Entity.Models;
using FanEase.Repository.Interfaces;

namespace FanEase.Repository.Services
{
    public class TemplateDetailsService : ITemplateDetailsService
    {
        readonly ITemplateDetailsRepository _templateDetailsRepository;

        public TemplateDetailsService(ITemplateDetailsRepository templateDetailsRepository)
        {
            _templateDetailsRepository = templateDetailsRepository;
        }
        public async Task<bool> AddTemplateDetails(TemplateDetail templateDetail)
        {
            return await _templateDetailsRepository.AddTemplateDetails(templateDetail);
        }

        public async Task<bool> DeleteTemplateDetails(int id)
        {
            return await _templateDetailsRepository.DeleteTemplateDetails(id);
        }

        public async Task<bool> EditTemplateDetails(TemplateDetail templateDetail)
        {
            return await _templateDetailsRepository.EditTemplateDetails(templateDetail);
        }

        public async Task<List<TemplateDetail>> GetAllTempletDetails()
        {
            return await _templateDetailsRepository.GetAllTempletDetails();
        }

        public async Task<TemplateDetail> GetTemplateDetailsById(int id)
        {
            return await _templateDetailsRepository.GetTemplateDetailsById(id);
        }
    }
}
