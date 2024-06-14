using FishManagementSystem.DBModels.Models;
using FishManagementSystem.IBussinessService;
using FishManagementSystem.Server.Utils;
using Microsoft.AspNetCore.Mvc;

namespace FishManagementSystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : FishControllerBase
    {


        public HomeController(IDataService dataService, ILogger<HomeController> logger) : base(dataService, logger) { }



        //// GET: HomeController
        //[HttpGet(Name = "LogsDetails")]
        //public IEnumerable<TStudent> LogsDetails()
        //{
        //    return dataService.Get<TStudent>();

        //}

        // GET: HomeController
        [HttpGet(Name = "SystemUsers")]
        public IEnumerable<TSystemUsers> SystemUsers()
        {
            _logger.LogInformation("i am here");
            return _dataService.Get<TSystemUsers>();
        }


        [HttpPost(Name = "AddSystemUser")]
        public bool AddSystemUser(TSystemUsers users)
        {

            _dataService.Add<TSystemUsers>(users);

            return true;


        }


    }
}
