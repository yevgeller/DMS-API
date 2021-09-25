using DMS.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using DMS.API.Data;

namespace DMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly object _key;
        private readonly string _key2;
        StudentDAL studentDAL;

        public StudentsController(IConfiguration config)
        {
            _key = config["db:connstr"];
            _key2 = config.GetConnectionString("db");
            studentDAL = new StudentDAL(config);
        }

        [HttpGet]
        [Route("GetAllStudents")]
        public IEnumerable<Student> GetAll()
        {
            return new List<Student>
            {
                new Student{Student_Id = 1, Name ="John Jones", BirthDate=new DateTime(2015, 1, 10)},
                new Student{Student_Id=2, Name = "Mary Jones", BirthDate = new DateTime(2015,1,20)},
                new Student{Student_Id =3, Name ="Kelly Michaels", BirthDate=new DateTime(2015, 1, 30)}
            };
        }

        [HttpGet]
        [Route("GetStudentById")]
        public Student GetStudentById(int id)
        {
            var student = studentDAL.GetStudentById(id);

            if (student == null)
            {
                throw new Exception("No such student");
            }

            return student;
            // Get the connectionStrings section.
            //Configuration.GetConnectionString("db");


            //string cs = WebConfigurationManager.ConnectionStrings["db"].ConnectionString;

            //if (cs == null)
            //    throw new Exception("Could not locate DB connection string");

            //return cs;
            //return new Student();
        }
    }
}
