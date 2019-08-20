using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace DapperDao
{
    class Program
    {
        public static IDapperDao dao = new DapperDao();
        public static IConnectionSetup connectionSetup = new ConnectionSetup();

        static async Task Main(string[] args)
        {
            var query = "usp_GetAllBlogPostByPageIndex";
            var param = new DynamicParameters();
            param.Add("@PageIndex", 1);
            param.Add("@PageSize", 4);
            var reader = connectionSetup.GetConnection.QueryMultiple(query, param: param, commandType: CommandType.StoredProcedure);

            var CategoryOneList = reader.Read<dynamic>().ToList();
            var CategoryTwoList = reader.Read<dynamic>().ToList();
            Task<GridReader> reader1 =  TestMultipleResultSet(1, 4);
            Console.WriteLine("Hello World!");
        }

        public async static Task<GridReader> TestMultipleResultSet(int pageIndex, int pageSize)
        {
            var query = "usp_GetAllBlogPostByPageIndex";
            var param = new DynamicParameters();
            param.Add("@PageIndex", pageIndex);
            param.Add("@PageSize", pageSize);
            var reader = dao.ReceiveBulkData(query, param);
            //var list = await SqlMapper.QueryAsync<Blog>(_connectionFactory.GetConnection, query, param, commandType: CommandType.StoredProcedure);

            //var reader = _connectionFactory.GetConnection.QueryMultiple(query, param: param, commandType: CommandType.StoredProcedure);
            //var CategoryOneList = reader.Read<Blog>().ToList();
            //var CategoryTwoList = reader.Read<ResultDrive>().ToList();
            //return reader;

            return await reader;
        }
    }
    public class Blog
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; }
        public string ShortPostContent { get; set; }
        public string FullPostContent { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public DateTime PostAddedDate { get; set; }
        public DateTime PostUpdatedDate { get; set; }
        public bool IsCommented { get; set; }
        public bool IsShared { get; set; }
        public bool IsPrivate { get; set; }
        public int NumberOfViews { get; set; }
        public string PostUrl { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual Category Categories { get; set; }

    }
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategorySlug { get; set; }
        public string CategoryImage { get; set; }
        public List<Blog> Posts { get; set; }
    }
}
