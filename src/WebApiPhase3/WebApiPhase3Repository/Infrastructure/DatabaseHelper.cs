using System.Data;
using System.Data.SqlClient;

namespace WebApiPhase3Repository.Infrastructure
{
    public class DatabaseHelper : IDatabaseHelper
    {
        /// <summary>
        /// 建立連線
        /// </summary>
        /// <returns></returns>
        public IDbConnection GetConnection(string connectionString)
        {
            var conn = new SqlConnection(connectionString);

            return conn;
        }
    }
}