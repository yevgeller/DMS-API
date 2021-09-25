using Dapper;
using DMS.API.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.Linq;

namespace DMS.API.Data
{
    public class StudentDAL
    {
        private string connFromSecrets;
        private string connFromAppPool;

        public StudentDAL(IConfiguration config)
        {
            connFromSecrets = config["db:connstr"];
            connFromAppPool = config.GetConnectionString("db");
        }

        public Student GetStudentById(int id)
        {
            using(var conn = new SqlConnection(connFromSecrets ?? connFromAppPool))
            {
                Student student = conn.Query<Student>("SELECT TOP 1 * FROM Student WHERE Student_Id = @Student_Id", new { Student_Id = id }).SingleOrDefault();
                return student;
            }
        }
    }
}
