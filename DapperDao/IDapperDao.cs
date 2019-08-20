using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DapperDao
{
    public interface IDapperDao
    {
        void PowerOn();
        void PowerOff();
        void GetConnection();
        Task<GridReader> ReceiveBulkData(string query, DynamicParameters param);
        Task<IEnumerable<dynamic>> ReceiveTableData(string query, DynamicParameters param);
        Task<dynamic> ReceiveRowData(string query, DynamicParameters param);
        Task<IEnumerable<Object>> ReceiveTableDataObject(string query, DynamicParameters param);
        Task<Object> ReceiveRowDataObject(string query, DynamicParameters param);

    }
}
