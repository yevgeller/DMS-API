using DMS.API.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmergentSoftwareController : Controller
    {
        [HttpGet]
        [Route("/EmergentSoftwareList")]
        public IEnumerable<Software> GetEmergentSoftware()
        {
            var result = SoftwareManager.GetAllSoftware();
            return result;
        }
    }
}
