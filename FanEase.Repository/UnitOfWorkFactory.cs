using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FanEase.Repository
{
    public class UnitOfWorkFactory
    {
        public static IUnitOfWork Create()
        {
            string connectionString = "Data Source=DESKTOP-4C8CQ3J\\SQLEXPRESS;Database=FanEase;Integrated Security=True;Trust Server Certificate=True;";

            var connection = new SqlConnection(connectionString);
            connection.Open();

            return new AdoNetUnitOfWork(connectionString, true);
        }
    }
}
