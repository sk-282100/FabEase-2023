using Dapper;
using FanEase.Entity.Models;
using FanEase.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Repository.Repositories
{
    public class StateRepository : IStateRepository
    {
        string connectionString;

        private readonly IConfiguration _configuration;

        public StateRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("Key");
        }

        public async Task<List<State>> GetAllState()
        {
            List<State> states = new List<State>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                states = connection.Query<State>("GetAllStateProcedure", commandType: CommandType.StoredProcedure).ToList();

            }
            return states;
        }

        public async Task<bool> AddState(State state)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var result = connection.Execute("AddStateProcedure", new { @StateName=state.StateName, @CountryId=state.CountryId}, commandType: CommandType.StoredProcedure);

                if (result > 0)
                    return true;
                return false;
            }
        }

        public async Task<State> GetStateById(int id)
        {
            State states = new State();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                states = connection.Query<State>("GetStateByIdProcedure", new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return states;
        }

        public async Task<bool> DeleteState(int id)
        {

            State state = new State();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                state = connection.Query<State>("GetStateByIdProcedure", new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                if (state != null)
                {
                    var result = connection.Execute("DeleteStateProcedure", new { id }, commandType: CommandType.StoredProcedure);
                    if (result > 0)
                        return true;
                }
                return false;
            }

        }

        public async Task<bool> UpdateState(State state)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Execute("EditStateProcedure", state, commandType: CommandType.StoredProcedure);
                if (result > 0)
                    return true;
                return false;
            }
        }
    }
}
