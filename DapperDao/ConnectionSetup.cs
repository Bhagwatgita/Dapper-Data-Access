using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;
using System.IO;

namespace DapperDao
{

    public class ConnectionSetup : IConnectionSetup
    {

        private readonly string connectionString = GetConnectionString();
        
        public IDbConnection GetConnection
        {
            get
            {
                var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                var conn = factory.CreateConnection();
                conn.ConnectionString = connectionString;
                conn.Open();
                return conn;
            }
            
        }

        private static  string GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                                   .SetBasePath(Directory.GetCurrentDirectory())
                                   .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            return configuration.GetConnectionString("DefaultConnection");

        }

        #region IDisposable Support
        private bool disposedValue = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    
                }

                disposedValue = true;
            }
        }

       
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
