

using FanEase.Entity.Models;
using FanEase.Repository.Interfaces;

namespace FanEase.Repository.Services
{
    public class VideoService : IVideoService
    {
        readonly IVideoRepository _videoRepository;

        public VideoService(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }
        public Task<bool> AddVideo(Video video)
        {
        
            return _videoRepository.AddVideo(video);  
            
        }

        public Task<bool> DeleteVideo(int id)
        {
            return _videoRepository.DeleteVideo(id);
        }

        public Task<bool> EditVideo(Video video)
        {
           return _videoRepository.EditVideo(video);
        }

        public Task<List<Video>> GetAllVideos()
        {
            return _videoRepository.GetAllVideos();
        }

        public Task<Video> GetVideoById(int id)
        {
            return _videoRepository.GetVideoById(id);
        }
    }
}
