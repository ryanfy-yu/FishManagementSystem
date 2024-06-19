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
    /// <summary>
    /// home页面
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HomeController : FishControllerBase
    {
        public readonly ISystemUsersDataService _dataService;


        public HomeController(ISystemUsersDataService dataService, IMapper mapper, ILogger<HomeController> logger) : base(logger, mapper)
        {
            _dataService = dataService;

        }
      


    }
}
