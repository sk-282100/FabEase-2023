

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
        public async Task<bool> AddVideo(Video video)
        {
        
            return await _videoRepository.AddVideo(video);  
            
        }

        public async Task<bool> DeleteVideo(int id)
        {
            return await _videoRepository.DeleteVideo(id);
        }

        public async Task<bool> EditVideo(Video video)
        {
           return await _videoRepository.EditVideo(video);
        }

        public async Task<List<Video>> GetAllVideos()
        {
            return await _videoRepository.GetAllVideos();
        }

        public async Task<Video> GetVideoById(int id)
        {
            return await _videoRepository.GetVideoById(id);
        }
    }
}
