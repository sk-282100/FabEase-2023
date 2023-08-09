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
        string connectionString;

        public TemplateDetailsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("Key");
        }

        
        public async Task<bool> AddTemplateDetails(TemplateDetail templateDetail)
        {
            
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
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var parameters = new {TemplateTitle=templateDetail.TemplateTitle, TemplateType=templateDetail.TemplateType, Section1=templateDetail.Section1,
                Section2=templateDetail.Section2,Section3=templateDetail.Section3,Section4=templateDetail.Section4,Section5=templateDetail.Section5,
                Section6=templateDetail.Section6,Section7=templateDetail.Section7,Section8=templateDetail.Section8,
                    TemplateDetailsId = templateDetail.TemplateDetailsId
                };
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
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                TemplateDetail template =  connection.Query<TemplateDetail>("GetTemplateDetailsByIdProcedure",new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();

                return template;
            }
        }

        public async Task<int> LatestAddedTemplateDetails(string userId)
        {
            int templateDetailsId;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                templateDetailsId = connection.ExecuteScalar<int>("LatestAddedTemplateDetailsSP", new { @UserId = userId }, commandType: CommandType.StoredProcedure);

            }

            return templateDetailsId;
        }
    }
}
