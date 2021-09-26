using Dapper;
using DMS.API.Data.Contracts;
using DMS.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.API.Data.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DapperContext ctx;

        public StudentRepository(DapperContext _ctx)
        {
            ctx = _ctx;
        }


        public async Task<IEnumerable<Student>> GetAll()
        {
            using (var conn = ctx.CreateConnection())
            {
                var students = await conn.QueryAsync<Student>("SELECT * FROM Students");
                return students.ToList();
            }
        }

        public async Task<Student> GetStudentById(int id)
        {
            var query = "SELECT * FROM Students WHERE Student_Id = @Student_Id";

            using(var conn = ctx.CreateConnection())
            {
                var student = await conn.QueryFirstOrDefaultAsync<Student>(query, new { Student_Id = id });
                return student;
            }
        }
    }
}
