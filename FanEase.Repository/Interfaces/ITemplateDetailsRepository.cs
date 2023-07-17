using FanEase.Entity.Models;

namespace FanEase.Repository.Interfaces
{
    public interface ITemplateDetailsRepository
    {
        Task<bool> AddTemplateDetails(TemplateDetail templateDetail);
        Task<bool> DeleteTemplateDetails(int id);
        Task<bool> EditTemplateDetails(TemplateDetail templateDetail);
        Task<List<TemplateDetail>> GetAllTempletDetails();
        Task<TemplateDetail> GetTemplateDetailsById(int id);
    }
}
