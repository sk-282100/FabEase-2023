

using FanEase.Entity.Models;

namespace FanEase.Repository.Interfaces
{
    public interface IVideoRepository
    {
        Task<bool> AddVideo(Video video);
        Task<bool> DeleteVideo(int id);
        Task<bool> EditVideo(Video video);
        Task<List<Video>> GetAllVideos();
        Task<List<Video>> GetVideoByCreatorId(string creatorId);
        Task<Video> GetVideoById(int id);
    }
}
