using FanEase.Entity.Models;

namespace FanEase.Repository.Interfaces
{
    public interface IPlayerRepository
    {
        Task<int> CreatePlayer(players Player);
        Task<int> DeletePlayer(int palyerId);
        public Task<List<players>> GetAllPlayers();
        Task<players> GetPlayerById(int playerId);
        Task<int> UpdatePlayer(players players);
    }
}
