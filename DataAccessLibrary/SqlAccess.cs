using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class SqlAccess : ISqlAccess
    {
        private readonly IConfiguration _config;
        public string ConnectionStringName { get; set; } = "goodrProjContext";
        public SqlAccess(IConfiguration config)
        {
            _config = config;
        }
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connnectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new SqlConnection(connnectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters);
                return data.ToList();
            }
        }
        public async Task SaveData<T>(string sql, T parameters)
        {
            string connnectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new SqlConnection(connnectionString))
            {
                await connection.ExecuteAsync(sql, parameters);
            }
        }

        public int[] GetGenderNumbers()
        {
            int males;
            int females;
            int other;
            string connnectionString = _config.GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new SqlConnection(connnectionString))
            {
                males = connection.ExecuteScalar<int>(@"select COUNT(*) from dbo.Employee Where Gender='MALE'");
                females = connection.ExecuteScalar<int>(@"select COUNT(*) from dbo.Employee Where Gender='FEMALE'");
                other = connection.ExecuteScalar<int>(@"select COUNT(*) from dbo.Employee");
            }
            int[] done = { males, females, other- (males + females) };

            return done;
        }
    }
}
