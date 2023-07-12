

using FanEase.Entity.Models;
using FanEase.Repository.Interfaces;

namespace FanEase.Repository.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerService(IPlayerRepository PlayerRepository)
        {
            _playerRepository = PlayerRepository;
        }
        public async Task<Response> CreatePlayerAsync(players Player)
        {
            int rowsAffected = await _playerRepository.CreatePlayer(Player);

            Response data = new Response
            {
                Result = rowsAffected > 0 ? Player : null,
                Message = rowsAffected > 0 ? "Player created successfully" : "Failed to create Player",
                IsSuccess = rowsAffected > 0
            };

            return data;
        }

        public async Task<Response> DeletePlayerAsync(int palyerId)
        {
            int rowsAffected = await _playerRepository.DeletePlayer(palyerId);

            Response data = new Response
            {
                Result = rowsAffected > 0 ? palyerId : null,
                Message = rowsAffected > 0 ? "Player deleted successfully" : "Failed to delete Player",
                IsSuccess = rowsAffected > 0
            };

            return data;
        }

        public async Task<Response?> GetAllPlayersAsync()
        {
            List<players> players = await _playerRepository.GetAllPlayers();
            Response data = new()
            {
                Result = players,
                Message = "All Player",
                IsSuccess = true,
            };
            return data;
        }

        public async Task<Response> GetPlayerByIdAsync(int playerId)
        {
            players players = await _playerRepository.GetPlayerById(playerId);


            Response data = new Response
            {
                Result = players,
                Message = "Player found",
                IsSuccess = true
            };
            return data;
        }

        public async Task<Response> UpdatePlayerAsync(players Player)
        {
            int rowsAffected = await _playerRepository.UpdatePlayer(Player);

            Response data = new Response
            {
                Result = rowsAffected > 0 ? Player : null,
                Message = rowsAffected > 0 ? "Player created successfully" : "Failed to create Player",
                IsSuccess = rowsAffected > 0
            };

            return data;
        }
    }
}
