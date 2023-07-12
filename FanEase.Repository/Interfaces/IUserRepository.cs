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
    }
}
