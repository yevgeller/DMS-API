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

namespace DMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly object _key;
        private readonly string _key2;

        public StudentsController(IConfiguration config)
        {
            _key = config["db:connstr"];
            _key2 = config.GetConnectionString("db");
        }

        [HttpGet]
        [Route("GetAllStudents")]
        public IEnumerable<Student> GetAll()
        {
            return new List<Student>
            {
                new Student{Student_Id = 1, First_Name="John", Last_Name = "Jones"},
                new Student{Student_Id=2, First_Name = "Mary", Last_Name = "Jones"},
                new Student{Student_Id =3, First_Name="Kelly", Last_Name="Michaels"}
            };
        }

        [HttpGet]
        [Route("GetStudentById")]
        public Student GetStudentById(int id)
        {
            return new Student { Student_Id = 0, First_Name = _key2.Substring(0, 5), Last_Name = _key2.Substring(5, 5) };

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
