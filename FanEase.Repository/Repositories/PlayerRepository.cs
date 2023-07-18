using Dapper;
using FanEase.Entity.Models;
using FanEase.Repository.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;

namespace FanEase.Repository.Repositories
{
    public class PlayerRepository : BaseRepository, IPlayerRepository
    {
        public PlayerRepository(IConfiguration config, ILogger<BaseRepository> logger) : base(config, logger)
        {

        }

        public async Task<int> CreatePlayer(players Player)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Name", Player.name);
            parameters.Add("@position", Player.position);
            parameters.Add("@jerseyNo", Player.jerseyNo);
            parameters.Add("@teamId", Player.teamId);


            int rowsAffected = await ExecuteAsync("CreatePlayer", parameters, CommandType.StoredProcedure);
            return rowsAffected;
        }

        public async Task<int> DeletePlayer(int palyerId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@PlayerId", palyerId);

            int rowsAffected = await ExecuteAsync("DeletePlayer", parameters, CommandType.StoredProcedure);
            return rowsAffected;
        }

        public async Task<List<players>> GetAllPlayers()
        {
            IEnumerable<players> players = await QueryAsync<players>("GetAllPlayers", null, CommandType.StoredProcedure);
            return players.ToList();
        }

        public async Task<players> GetPlayerById(int playerId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@PlayerId", playerId);

            players player = await GetByIdAsync<players>("GetPlayerById", parameters, CommandType.StoredProcedure);
            return player;
        }

        public async Task<int> UpdatePlayer(players players)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@PlayerId", players.palyerId);
            parameters.Add("@Name", players.name);
            parameters.Add("@Position", players.position);
            parameters.Add("@JerseyNo", players.jerseyNo);
            parameters.Add("@TeamId", players.teamId);

            int rowsAffected = await ExecuteAsync("UpdatePlayer", parameters, CommandType.StoredProcedure);
            return rowsAffected;

        }


    }
}
