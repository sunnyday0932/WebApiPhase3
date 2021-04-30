using System.Data;
using System.Data.SqlClient;
using CoreProfiler;
using CoreProfiler.Data;

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
            var conn = new ProfiledDbConnection
                (
                    new SqlConnection(connectionString),
                    () => ProfilingSession.Current is null
                        ? null
                        : new DbProfiler(ProfilingSession.Current.Profiler)
                );

            return conn;
        }
    }
}