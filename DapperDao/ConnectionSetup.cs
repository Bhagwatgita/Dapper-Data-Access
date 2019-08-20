using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace DapperDao
{

    public class ConnectionSetup : IConnectionSetup
    {

        private readonly string connectionString = GetConnectionString();
        
        public IDbConnection GetConnection
        {
            get
            {
                DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);
                // Get the provider invariant names
                IEnumerable<string> invariants = DbProviderFactories.GetProviderInvariantNames(); // => 1 result; 'System.Data.SqlClient'

                // Get a factory using that name
                DbProviderFactory factory = DbProviderFactories.GetFactory(invariants.FirstOrDefault());

                // Create a connection and set the connection string
                var conn = factory.CreateConnection();
                conn.ConnectionString = connectionString;
                try { conn.Open(); } catch (Exception ex) { }
                
                return conn;
            }
            
        }

        private static  string GetConnectionString()
        {
            //var builder = new ConfigurationBuilder()
            //                       .SetBasePath(Directory.GetCurrentDirectory())
            //                       .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            //IConfigurationRoot configuration = builder.Build();
            //var result= configuration.GetConnectionString("DefaultConnection");

            //return result;
            return "Server=STPL-PC-GME;User Id=sa;Password=sasa;Database=TodoItemsDB03;";

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
