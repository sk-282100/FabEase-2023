﻿using Dapper;
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

                var result = connection.Execute("AddTemplateProcedure", new{ @TemplateDetailsId = templates.TemplateDetailsId, @PublishStatus=templates.PublishStatus, @VideoStatus=templates.VideoStatus }, commandType: CommandType.StoredProcedure);

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

        public async Task<List<TemplateListDTO>> GetAllTemplatesAsync()
        {
            List<TemplateListDTO> templates = new List<TemplateListDTO>();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                templates = connection.Query<TemplateListDTO>("GetAllTemplatesProcedure", commandType: CommandType.StoredProcedure).ToList();

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

        public async Task<List<TemplateListDTO>> GetAllTemplatesByUser(string userId)
        {
            List<TemplateListDTO> templates = new List<TemplateListDTO>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                templates = connection.Query<TemplateListDTO>("GetAllTemplatesByUserProcedure", new { @UserId= userId }, commandType: CommandType.StoredProcedure).ToList();
            }
            return templates;
        }

        public async Task<int> LatestAddedTemplate(string userId)
        {
            int templateId;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                templateId = connection.ExecuteScalar<int>("LatestAddedTemplateSP", new { @UserId = userId }, commandType: CommandType.StoredProcedure);

            }

            return templateId;
        }
    }
}
