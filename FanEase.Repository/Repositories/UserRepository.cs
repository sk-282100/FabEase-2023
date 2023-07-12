using Dapper;
using FanEase.Entity.Models;
using FanEase.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace FanEase.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {

        readonly IConfiguration _configuration;

        string connectionString;
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("key");
        }



        public async Task<bool> AddUser(User user)
        {
            using (var db = new SqlConnection(connectionString))
            {
                db.Open();
                var result = await db.ExecuteAsync("AddUser", user, commandType: CommandType.StoredProcedure);
                if (result > 0)
                {
                    return true;
                }

                return false;

            }
        }

        public async Task<bool> DeleteUser(string id)
        {

            User user = new User();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                user = connection.Query<User>("GetUserById", new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                if (user != null)
                {
                    var result = connection.Execute("DeleteUser", new { id }, commandType: CommandType.StoredProcedure);
                    if (result > 0)
                        return true;
                }
                return false;
            }

        }

        public async Task<bool> EditUser(User user)
        {


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();



                var result = connection.Execute("UpdateUser", user, commandType: CommandType.StoredProcedure);
                if (result > 0)
                    return true;

                return false;
            }
        }



        public async Task<List<User>> GetAllUsers()
        {
            List<User> users = new List<User>();

            string connectionString = _configuration.GetConnectionString("Key");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                users = connection.Query<User>("GetUserList", commandType: CommandType.StoredProcedure).ToList();
            }

            return users;
        }

        public async Task<User> GetUserById(string id)
        {
            string connectionString = _configuration.GetConnectionString("Key");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                User user = connection.Query<User>("GetUserById", new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return user;
            }
        }

    }
}
