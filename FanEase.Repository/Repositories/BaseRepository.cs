using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace FanEase.Repository.Repositories
{
    public class BaseRepository
    {
        private readonly IConfiguration _config;
        private readonly ILogger _logger;
        private string Connectionstring = "Key";

        public BaseRepository(IConfiguration config, ILogger<BaseRepository> logger)
        {
            _logger = logger;
            _config = config;
        }

        public DbConnection GetDbconnection()
        {
            return new SqlConnection(_config.GetConnectionString(Connectionstring));
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            IEnumerable<T> result;
            string connectionString = _config.GetConnectionString(Connectionstring);
            using IDbConnection db = new SqlConnection(connectionString);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                result = await db.QueryAsync<T>(sp, parms, commandType: commandType);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result.ToList();
        }

        public async Task<T> GetByIdAsync<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            string connectionString = _config.GetConnectionString(Connectionstring);
            using IDbConnection db = new SqlConnection(connectionString);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                result = await db.QuerySingleOrDefaultAsync<T>(sp, parms, commandType: commandType);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }

        public async Task<int> ExecuteAsync(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            int rowsAffected;
            string connectionString = _config.GetConnectionString(Connectionstring);
            using IDbConnection db = new SqlConnection(connectionString);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                rowsAffected = (await db.QueryAsync<int>(sp, parms, commandType: commandType)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return rowsAffected;
        }
        /// <summary>
        /// update
        /// </summary>
        /// <param name="sp"></param>
        /// <param name="parms"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            int rowsAffected;
            string connectionString = _config.GetConnectionString(Connectionstring);
            using IDbConnection db = new SqlConnection(connectionString);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                rowsAffected = await db.ExecuteAsync(sp, parms, commandType: commandType);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return rowsAffected;
        }
        public async Task<int> DeleteAsync(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            int rowsAffected;
            string connectionString = _config.GetConnectionString(Connectionstring);
            using IDbConnection db = new SqlConnection(connectionString);
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                rowsAffected = await db.ExecuteAsync(sp, parms, commandType: commandType);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return rowsAffected;
        }
    }
}
