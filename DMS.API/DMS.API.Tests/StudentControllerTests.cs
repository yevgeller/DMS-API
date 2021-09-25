using DMS.API.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DMS.API.Tests
{
    [TestClass]
    public class StudentControllerTests
    {

        StudentsController sc;
        private static IConfiguration config;
        //public TestContext TestContext { get; set; }

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            config = TestHelper.GetIConfigurationRoot(context.TestDir);
            var connStr = config["db:connstr"];
            
        }

        [TestInitialize()]
        public void InitTests()
        {
            sc = new StudentsController(config);
            var i = 1;
        }


        [TestMethod]
        public void TestMethod1()
        {

            Assert.IsTrue(true);


        }
    }
}
