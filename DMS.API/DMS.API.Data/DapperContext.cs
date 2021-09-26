using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.API.Data
{
    //https://code-maze.com/using-dapper-with-asp-net-core-web-api/
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            string connFromSecrets = _configuration["db:connstr"];
            string connFromAppPool = _configuration.GetConnectionString("db");
            _connectionString = connFromSecrets ?? connFromAppPool;
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
