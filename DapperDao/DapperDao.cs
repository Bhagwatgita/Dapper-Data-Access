using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DapperDao
{
    public class DapperDao: IDapperDao
    {
        IConnectionSetup connectionSetup;
        int connectionStatus = 200;
        public DapperDao()
        {
            GetConnection();
        }

        public  void GetConnection()
        {
            connectionSetup = new ConnectionSetup();
        }

        public  void PowerOn()
        {
            if (connectionSetup.GetConnection.State != ConnectionState.Open)
            {
                connectionSetup.GetConnection.Close();
            }
            try
            {
                connectionSetup.GetConnection.Open();
            }
            catch (Exception ) {
                connectionStatus = 500;
            }
        }

        public void PowerOff()
        {
            if (connectionSetup.GetConnection.State != ConnectionState.Open)
            {
                connectionSetup.GetConnection.Close();
            }
            
        }

        public async Task<GridReader> ReceiveBulkData(string query, DynamicParameters param)
        {
            var reader = await connectionSetup.GetConnection.QueryMultipleAsync(query, param: param, commandType: CommandType.StoredProcedure);
            return reader;
        }

        


    }
}
