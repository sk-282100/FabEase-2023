using ExceptionHandling;
using FanEase.Entity.Models;

namespace FanEase.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> AddUser(User user);
        Task<bool> DeleteUser(string id);
        Task<bool> EditUser(User user);
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(string id);
        Task<User> GetUserByUserName(string userName);
        Task<ResponseModel<AuthResponse>> Login(LoginDto loginDto);
        Task<ResponseModel<bool>> ResetPassword(string newPassword, string oldPassword, string userId);
        Task<ResponseModel<bool>> SetPassword(string userName, string password);
    }
}
