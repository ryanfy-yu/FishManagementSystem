using AutoMapper;
using FishManagementSystem.Commons;
using FishManagementSystem.DBModels.Models;
using FishManagementSystem.DTO;
using FishManagementSystem.IBussinessService;
using FishManagementSystem.Mapping;
using FishManagementSystem.Server.Utils;
using Microsoft.AspNetCore.Mvc;

namespace FishManagementSystem.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : FishControllerBase
    {
        public readonly ISystemUsersDataService _dataService;


        public HomeController(ISystemUsersDataService dataService, IMapper mapper, ILogger<HomeController> logger) : base(logger, mapper)
        {
            _dataService = dataService;

        }



        //// GET: HomeController
        //[HttpGet(Name = "LogsDetails")]
        //public IEnumerable<TStudent> LogsDetails()
        //{
        //    return dataService.Get<TStudent>();

        //}

        // GET: HomeController
        [HttpGet(Name = "SystemUsers")]
        public ApiResult SystemUsers()
        {
            //_logger.LogInformation("i am here");
            var data = _dataService.GetSystemUserInfo("string");

            var dtoData = _mapper.Map<SystemUsersDTO>(data);

            return new ApiResult()
            {
                Data = dtoData,
                IsSuccess = true,

            };

        }


        [HttpPost(Name = "AddSystemUser")]
        public bool AddSystemUser(TSystemUsers users)
        {

            _dataService.Add<TSystemUsers>(users);

            return true;


        }


    }
}
