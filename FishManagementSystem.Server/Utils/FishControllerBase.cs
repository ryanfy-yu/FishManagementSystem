using FishManagementSystem.IBussinessService;
using FishManagementSystem.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace FishManagementSystem.Server.Utils
{
    public class FishControllerBase : ControllerBase
    {

        public readonly IDataService _dataService;
        public readonly ILogger<dynamic> _logger;


        public FishControllerBase(IDataService dataService, ILogger<dynamic> logger)
        {
            _dataService = dataService;
            _logger = logger;

        }
    }
}
