using Dapper;
using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
                User user = connection.Query<User>("GetUserById", new { @USERID=id }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return user;
            }
        }

        private User _user { get; set; }
        public async Task<ResponseModel<AuthResponse>> Login(LoginDto loginDto)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Key")))
            {
                _user = connection.Query<User>("GetUserByUserName", new { @UsertName = loginDto.Email }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                bool isValidate = (loginDto.Password == _user.Password);
                if (_user == null || isValidate == false)
                {
                    return null;
                }
                var token = await GenerateToken();

                var authresponse = new AuthResponse
                {
                    Token = token,
                    UserId = _user.UserId
                };
                return new ResponseModel<AuthResponse> { data = authresponse };
            }
        }

        private async Task<string> GenerateToken()
        {
            List<string> roles;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSetting:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                 roles = connection.Query<string>("GetUserRoleSP", new {@UserId=_user.UserId},commandType: CommandType.StoredProcedure).ToList();
            }
            var roleclaim = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,_user.Email),
                 new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                 //new Claim(JwtRegisteredClaimNames.Email,_user.Email),
                 new Claim("uid",_user.UserId),
                 new Claim(ClaimTypes.Email,_user.Email),
                 new Claim(ClaimTypes.Name,_user.FirstName+" "+_user.LastName),
                 new Claim("firstName",_user.FirstName)
                 

            }.Union(roleclaim);

            

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSetting:Issuer"],
                audience: _configuration["JwtSetting:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToInt64(_configuration["JwtSetting:DurationInMinutes"])),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }



        public async Task<ResponseModel<bool>> ResetPassword(string newPassword, string oldPassword, string userId)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();



                var result = connection.Execute("ResetPassword", new { @NEWPASSWORD = newPassword, @PASSWORD = oldPassword, @USERID = userId }, commandType: CommandType.StoredProcedure);
                if (result > 0)
                    return new ResponseModel<bool> { data = true };

                return new ResponseModel<bool> { message = "Try again", data = false };


            }
        }

        public async Task<ResponseModel<bool>> SetPassword(string userName, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var result = connection.Execute("SETPASSWORD", new { @PASSWORD = password, @USERNAME = userName }, commandType: CommandType.StoredProcedure);
                if (result > 0)
                    return new ResponseModel<bool> { data = true };

                return new ResponseModel<bool> { message = "Try again", data = false };


            }
        }

        public async Task<User> GetUserByUserName(string userName)
        {
            string connectionString = _configuration.GetConnectionString("Key");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                User user = connection.Query<User>("GetUserByUserName", new { @UsertName = userName }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return user;
            }
        }

        public async Task<List<User>> GetAllCreators()
        {
            List<User> users = new List<User>();

            string connectionString = _configuration.GetConnectionString("Key");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                users = connection.Query<User>("ContenetCreatorListSP", commandType: CommandType.StoredProcedure).ToList();
            }

            return users;
        }

        public async Task<bool> AddCreator(string creatorId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var result = connection.Execute("AddCreatorSP", new { @UserId = creatorId}, commandType: CommandType.StoredProcedure);
                if (result > 0)
                    return true;

                return false;

            }
        }

        public async Task<bool> RemoveCreator(string creatorId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var result = connection.Execute("RemoveCreatorSP", new { @UserId = creatorId }, commandType: CommandType.StoredProcedure);
                if (result > 0)
                    return true;

                return false;

            }
        }
    }
}
