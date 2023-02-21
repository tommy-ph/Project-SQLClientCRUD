using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SQLClientCRUD.Repositories
{
    public class ConnectionstringHelper
    {
        public static string GetConnectionString()
        {
            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder();
            connectionStringBuilder.DataSource = @"N-SE-01-4568\SQLEXPRESS01";
            connectionStringBuilder.InitialCatalog = "Chinook";
            connectionStringBuilder.IntegratedSecurity= true;
            connectionStringBuilder.TrustServerCertificate= true;
            return connectionStringBuilder.ConnectionString;
        }
    }
}
