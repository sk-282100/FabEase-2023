using FanEase.Entity.Models;

namespace FanEase.Repository.Interfaces
{
    public interface IPlayerService
    {
        Task<Response> CreatePlayerAsync(players Player);
        Task<Response> DeletePlayerAsync(int palyerId);
        public Task<Response?> GetAllPlayersAsync();
        Task<Response> GetPlayerByIdAsync(int palyerId);
        Task<Response> UpdatePlayerAsync(players Player);
    }
}
