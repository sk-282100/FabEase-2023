using FanEase.Entity.Models;

namespace FanEase.Repository.Interfaces
{
    public interface ITemplateRepository
    {
        Task<bool> AddTemplate(Templates templates);
        Task<List<Templates>> GetAllTemplatesAsync();
        Task<Templates> GetTemplatesById(int id);
        Task<bool> DeleteTemplates(int id);
        Task<bool> UpdateTemplates(Templates templates);
    }
}
