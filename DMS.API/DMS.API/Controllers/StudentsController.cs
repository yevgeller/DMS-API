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
using DMS.API.Data.Contracts;

namespace DMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly object _key;
        private readonly string _key2;
        StudentDAL studentDAL;
        private readonly IStudentRepository studentRepo;

        public StudentsController(IConfiguration config, IStudentRepository _studentRepo)
        {
            _key = config["db:connstr"];
            _key2 = config.GetConnectionString("db");
            studentDAL = new StudentDAL(config);
            studentRepo = _studentRepo;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Student))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Student> GetStudentById(int id)
        {
            var student = studentDAL.GetStudentById(id);

            if (student == null)
            {
                return new NotFoundObjectResult("No such student");
            }

            return student;
        }

        [HttpGet]
        [Route("GetAllStudents2")]
        public async Task<IEnumerable<Student>> GetAllViaDapper()
        {
            var result = await studentRepo.GetAll();
            return result;
        }

        [HttpGet]
        [Route("GetStudentById2")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Student))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Student>> GetStudentByIdViaDapper(int id)
        {
            var student = await studentRepo.GetStudentById(id);

            if (student == null)
            {
                return new NotFoundObjectResult("No such student");
            }

            return student;
        }
    }
}
