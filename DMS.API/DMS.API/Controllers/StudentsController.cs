using DMS.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
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
    }
}
