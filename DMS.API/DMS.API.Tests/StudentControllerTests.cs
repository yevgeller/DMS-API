using DMS.API.Controllers;
using DMS.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DMS.API.Tests
{
    [TestClass]
    public class StudentControllerTests
    {
        StudentsController sc;
        private static IConfiguration config;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            config = TestHelper.GetIConfigurationRoot(context.TestDir);
            var connStr = config["db:connstr"];
        }

        [TestInitialize()]
        public void InitTests()
        {
            sc = new StudentsController(config, null);
            var i = 1;
        }


        [TestMethod]
        public void GetAll_AssureThereAreAny()
        {
            IEnumerable<Student> students = sc.GetAll();
            Assert.IsTrue(students.ToList().Any());
        }

        [TestMethod]
        public void GetByInvalidId_Return404()
        {
            ActionResult<Student> student = sc.GetStudentById(-1);
            var res = student.Result as NotFoundObjectResult;
            Assert.IsTrue(res.StatusCode == 404);
        }

        [TestMethod]
        public void GetByValidId_ReturnStudent()
        {
            int studentId = 5;
            ActionResult<Student> student = sc.GetStudentById(studentId);
            var res = student.Value;
            Assert.IsTrue(res.Student_Id == studentId);
        }
    }
}
