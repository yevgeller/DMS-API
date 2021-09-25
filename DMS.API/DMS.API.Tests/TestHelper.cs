using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.API.Tests
{
    public class TestHelper
    {
        public static IConfigurationRoot GetIConfigurationRoot(string outputPath)
        {
            //https://weblog.west-wind.com/posts/2018/Feb/18/Accessing-Configuration-in-NET-Core-Test-Projects
            return new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", optional: true)
                .AddUserSecrets("bcec62a8-125e-4457-beda-9070409387e5")
                .AddEnvironmentVariables()
                .Build();
        }

    }
}