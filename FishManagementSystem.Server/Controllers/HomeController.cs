using FishManagementSystem.Models;
using FishManagementSystem.Server.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FishManagementSystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : FishControllerBase
    {
        // GET: HomeController
        [HttpGet(Name = "LogsDetails")]
        public IEnumerable<Logs> LogsDetails()
        {
           var list = db.Queryable<Logs>().ToList();

            return list;
        }

    
    }
}
