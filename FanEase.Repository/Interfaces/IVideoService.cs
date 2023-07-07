
using FanEase.Entity.Models;

namespace FanEase.Repository.Interfaces
{
    public interface IVideoService
    {
        Task<bool> AddVideo(Video video);
        Task<bool> DeleteVideo(int id);
        Task<bool> EditVideo(Video video);
        Task<List<Video>> GetAllVideos();
        Task<Video> GetVideoById(int id);
    }
}
