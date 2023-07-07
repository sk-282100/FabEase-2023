using Dapper;
using FanEase.Entity.Models;
using FanEase.Repository.Interfaces;
using Microsoft.Data.SqlClient;

namespace FanEase.Repository.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        string connectionString = "Data Source=DESKTOP-4C8CQ3J\\SQLEXPRESS;Database=FanEase;Integrated Security=True;Trust Server Certificate=True;";
        public async Task<bool> AddVideo(Video video)
        {
            string query = $"INSERT INTO Videos (videoImage, videoThumbnil, GoLive_DateTime, title, " +
                $"description, videoType, videoPlayer, videoURL, videofile, duration, isPublished, " +
                $"isActive, views, likes, dislikes, skipped, templateId, userId, campaignId) " +
                $"VALUES (@VideoImage,@VideoThumbnil,@GoLiveDateTime,@Title,@Description," +
                $"@VideoType,@VideoPlayer,@VideoURL,@VideoFile,@Duration,@IsPublished,@IsActive,@Views,@Likes," +
                $"@Dislikes,@Skipped,@TemplateId,@UserId,@CampaignId)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var result = connection.Execute(query,video);

                if (result > 0)
                    return true;
                return false;
            }

        }

        public async Task<bool> DeleteVideo(int id)
        {
            string query1 = $"select * from Videos where videoId={id}";
            string query2 = $"delete from Videos where videoId={id}";
            Video video = new Video();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                video = connection.Query<Video>(query1).FirstOrDefault();
                if(video!=null)
                {
                    var result=connection.Execute(query2);
                    if (result > 0)
                        return true;
                }
                return false;

            }

        }

        public async Task<bool> EditVideo(Video video)
        {
            string query = $"UPDATE Videos SET videoImage = @VideoImage, videoThumbnil = @VideoThumbnil, " +
                $"GoLive_DateTime = @GoLiveDateTime, " +
                $"title = @Title, description = @Description, videoType = @videoType," +
                $" videoPlayer = @VideoPlayer, videoURL = @VideoURL, videoFile = @VideoFile, " +
                $"duration = @Duration, isPublished = @IsPublished, " +
                $"isActive = @IsActive, views = @Views, likes = @Likes, " +
                $"Dislikes = @dislikes, skipped = @Skipped, templateId = @TemplateId, " +
                $"userId = @UserId, campaignId = @CampaignId WHERE videoId = @VideoId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
               var result = connection.Execute(query);
                if (result > 0)
                    return true;
                return false;
            }
            

        }

        public async Task<List<Video>> GetAllVideos()
        {
            List<Video> videos = new List<Video>();

            string query = "select * from Videos";

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                videos = connection.Query<Video>(query).ToList();
                
            }
             
            return videos;
        }

        public async Task<Video> GetVideoById(int id)
        {
            Video video = new Video();

            string query = $"select * from Videos where videoId={id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                video = connection.Query<Video>(query).FirstOrDefault();

            }

            return video;
        }
    }
}
