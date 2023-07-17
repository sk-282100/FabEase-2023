using Dapper;
using FanEase.Entity.Models;
using FanEase.Repository.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace FanEase.Repository.Repositories
{
    public class TemplateRepository : ITemplateRepository
    {
        string connectionString;

        private readonly IConfiguration _configuration;

        public TemplateRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("Key");
        }

        public async Task<bool> AddTemplate(Templates templates)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var result = connection.Execute("AddTemplateProcedure", templates, commandType: CommandType.StoredProcedure);

                if (result > 0)
                    return true;
                return false;
            }
        }

        public async Task<bool> DeleteTemplates(int id)
        {
            Templates templates = new Templates();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                templates = connection.Query<Templates>("GetTemplatesByIdProcedure", new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                if (templates != null)
                {
                    var result = connection.Execute("DeleteTemplatesProcedure", new { id }, commandType: CommandType.StoredProcedure);
                    if (result > 0)
                        return true;
                }
                return false;
            }
        }

        public async Task<List<Templates>> GetAllTemplatesAsync()
        {
            List<Templates> templates = new List<Templates>();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                templates = connection.Query<Templates>("GetAllTemplatesProcedure", commandType: CommandType.StoredProcedure).ToList();

            }
            return templates;
        }


        public async Task<Templates> GetTemplatesById(int id)
        {
            Templates templates = new Templates();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                templates = connection.Query<Templates>("GetTemplatesByIdProcedure", new { id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
            return templates;
        }

        public async Task<bool> UpdateTemplates(Templates templates)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                
                //var parameters = new
                //{
                //    TemplateDeatailsId = templates.TemplateDetailsId,
                //    UserId = templates.UserId
                //};
                connection.Open();
                var result = connection.Execute("EditTemplatesProcedure", templates, commandType: CommandType.StoredProcedure);
                if (result > 0)
                    return true;
                return false;
            }
        }
    }
}
