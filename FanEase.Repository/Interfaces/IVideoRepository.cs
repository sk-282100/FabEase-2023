
using FanEase.Entity.Models;

namespace FanEase.Repository.Interfaces
{
    public interface IVideoRepository
    {
        Task<bool> AddVideo(Video video);
        Task<bool> DeleteVideo(int id);
        Task<bool> EditVideo(Video video);
        Task<List<Video>> GetAllVideos();
        Task<Video> GetVideoById(int id);

        Task<List<Video>> GetVideosByUserId(string userId);

        Task<List<VideoListVm>> GetAllVideosList(); //For Video List Screen
        Task<List<VideoListVm>> GetVideosListScreenByUserId(string userId);
    }
}
