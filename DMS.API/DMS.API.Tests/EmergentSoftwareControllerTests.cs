using DMS.API.Controllers;
using DMS.API.Data.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace DMS.API.Tests
{
    [TestClass]
    public class EmergentSoftwareControllerTests
    {
        EmergentSoftwareController ec;
        private static IConfiguration config;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            config = TestHelper.GetIConfigurationRoot(context.TestDir);
            var connStr = config["db:connstr"];
        }

        [TestMethod]
        public void GetAll_AssureThereAreAny()
        {
            var software = ec.GetEmergentSoftware();
            Assert.IsTrue(software.ToList().Any());
        }

    }

}
