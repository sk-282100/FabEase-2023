﻿using Dapper;
using ExceptionHandling;
using FanEase.Entity.Models;
using FanEase.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace FanEase.Repository.Repositories
{
    public class VideoRepository : IVideoRepository
    {

        readonly IConfiguration _configuration;
        string connectionString;
        public VideoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("Key");
        }
        public async Task<bool> AddVideo(Video video)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Execute("AddVideoProcedure", video, commandType: CommandType.StoredProcedure);

                if (result > 0)
                    return true;
                return false;
            }

        }

        public async Task<bool> DeleteVideo(int id)
        {

            Video video = new Video();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                video = connection.Query<Video>("GetVideoByIdProcedure", new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                if (video != null)
                {
                    var result = connection.Execute("DeleteVideoProcedure", new { id }, commandType: CommandType.StoredProcedure);
                    if (result > 0)
                        return true;
                }
                return false;

            }

        }

        public async Task<bool> EditVideo(Video video)
        {
            var parameters = new
            {
                VideoImage = video.VideoImage,
                VideoThumbnil = video.VideoThumbnil,
                GoLiveDateTime = video.GoLiveDateTime,
                Title = video.Title,
                Description = video.Description,
                VideoType = video.VideoType,
                VideoPlayer = video.VideoPlayer,
                VideoURL = video.VideoURL,
                VideoFile = video.VideoFile,
                Duration = video.Duration,
                IsPublished = video.IsPublished,
                IsActive = video.IsActive,
                Views = video.Views,
                Likes = video.Likes,
                Dislikes = video.Dislikes,
                Skipped = video.Skipped,
                TemplateId = video.TemplateId,
                UserId = video.UserId,
                CampaignId = video.CampaignId,
                VideoId = video.VideoId
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Execute("EditVideoProcedure", parameters, commandType: CommandType.StoredProcedure);
                if (result > 0)
                    return true;
                return false;
            }

        }

        public async Task<List<Video>> GetAllVideos()
        {
            List<Video> videos = new List<Video>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                videos = connection.Query<Video>("GetAllVideosProcedure", commandType: CommandType.StoredProcedure).ToList();
            }

            return videos;
        }

        public async Task<Video> GetVideoById(int id)
        {
            Video video = new Video();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                video = connection.Query<Video>("GetVideoByIdProcedure", new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();

            }

            return video;
        }

        public async Task<List<Video>> GetVideosByUserId(string userId)
        {
            List<Video> videos = new List<Video>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                videos = connection.Query<Video>("GetVideosByUserIdSP", new { userId }, commandType: CommandType.StoredProcedure).ToList();

            }

            return videos;
        }


        public async Task<List<VideoListVm>> GetAllVideosList()
        {
            List<VideoListVm> videosList = new List<VideoListVm>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                videosList = connection.Query<VideoListVm>("VideoListScreenProcedure", commandType: CommandType.StoredProcedure).ToList();
            }

            return videosList;
        }

        public async Task<List<VideoListVm>> GetVideosListScreenByUserId(string userId)
        {
            List<VideoListVm> videos = new List<VideoListVm>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                videos = connection.Query<VideoListVm>("VideoListScreenProcedureByUserId", new { userId }, commandType: CommandType.StoredProcedure).ToList();

            }

            return videos;
        }

        public async Task<int> LatestAddedVideo(string userId)
        {
            int videoId;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                videoId = connection.ExecuteScalar<int>("LatestAddedVideoSP", new {@UserId= userId }, commandType: CommandType.StoredProcedure);
                
            }

            return videoId;
        }

  

        public async Task<bool> AssignCampaign(int? videoId, int? campaignId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Execute("AssignCampaignSP", new {@VideoId=videoId,@CampaignId=campaignId}, commandType: CommandType.StoredProcedure);
                
                if (result > 0)
                    return true;
                return false;
            }
        }

        public async Task<bool> AssignTemplate(int? videoId, int? templateId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = connection.Execute("AssignTemplateSP", new { @VideoId = videoId, @TemplateId = templateId }, commandType: CommandType.StoredProcedure);

                if (result > 0)
                    return true;
                return false;
            }
        }
    }

}
