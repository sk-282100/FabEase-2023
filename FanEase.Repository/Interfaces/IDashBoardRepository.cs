using FanEase.Entity.Models;

namespace FanEase.Repository.Interfaces
{
    public interface IDashBoardRepository
    {
        Task<AdminDashboardDTO> GetAdminDashBoard();
    }
}
