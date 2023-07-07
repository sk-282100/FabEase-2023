using Dapper;
using FanEase.Entity.Models;
using FanEase.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System.Data;

namespace FanEase.Repository.Repositories
{
    public class TemplateDetailsRepository : ITemplateDetailsRepository
    {
        readonly IConfiguration _configuration;

        public TemplateDetailsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        
        public async Task<bool> AddTemplateDetails(TemplateDetail templateDetail)
        {
            string connectionString = _configuration.GetConnectionString("Key");
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var result = await connection.ExecuteAsync("AddTemplateDetailsProcedure",templateDetail, commandType: CommandType.StoredProcedure);
                if (result > 0)
                    return true;
                return false;
            }
        }

        public async Task<bool> DeleteTemplateDetails(int id)
        {
            string connectionString = _configuration.GetConnectionString("Key");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                TemplateDetail template = connection.Query<TemplateDetail>("GetTemplateDetailsByIdProcedure", new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                if (template != null)
                {
                    var result = await connection.ExecuteAsync("DeleteTemplateDetailsProcedure", new { id }, commandType: CommandType.StoredProcedure);
                    if (result > 0)
                        return true;
                }
                return false;

            }
        }

        public async Task<bool> EditTemplateDetails(TemplateDetail templateDetail)
        {
            string connectionString = _configuration.GetConnectionString("Key");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var parameters = new { ThumbnilImage = templateDetail.ThumbnilImage, TemplateTitle=templateDetail.TemplateTitle, TemplateType=templateDetail.TemplateType, TemplateDetailsId = templateDetail.TemplateDetailsId };
                var result = await connection.ExecuteAsync("EditTemplateDetails", parameters, commandType: CommandType.StoredProcedure);
                if (result > 0)
                    return true;
                return false;

            }
        }

        public async Task<List<TemplateDetail>> GetAllTempletDetails()
        {
            string connectionString = _configuration.GetConnectionString("Key");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                List<TemplateDetail> templates =  connection.Query<TemplateDetail>("GetAllTempletDetailsProcedure", commandType: CommandType.StoredProcedure).ToList();

                return templates;
            }
        }

        public async Task<TemplateDetail> GetTemplateDetailsById(int id)
        {
            string connectionString = _configuration.GetConnectionString("Key");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                TemplateDetail template =  connection.Query<TemplateDetail>("GetTemplateDetailsByIdProcedure",new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return template;
            }
        }
    }
}
