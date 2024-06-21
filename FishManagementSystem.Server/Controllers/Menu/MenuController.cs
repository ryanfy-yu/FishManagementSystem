using AutoMapper;
using FishManagementSystem.Commons;
using FishManagementSystem.DBModels.Models;
using FishManagementSystem.DTO;
using FishManagementSystem.IBussinessService;
using FishManagementSystem.Mapping;
using FishManagementSystem.Server.Utils;
using FishManagementSystem.Swagger;
using Microsoft.AspNetCore.Mvc;

namespace FishManagementSystem.Server.Controllers.Menu
{
    /// <summary>
    /// 系统用户
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MenuController : FishControllerBase
    {
        public readonly IDataService _dataService;


        public MenuController(IDataService dataService, IMapper mapper, ILogger<MenuController> logger) : base(logger, mapper)
        {
            _dataService = dataService;

        }


        /// <summary>
        /// GetSystemMenuList
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetMenuList")]
        [ApiExplorerSettings(GroupName = nameof(ApiVersion.v1))]
        public ApiResult GetSystemMenuList()
        {
            //_logger.LogInformation("i am here");
            var tData = _dataService.Get<TSystemMenus>();

            var dataList = _mapper.Map<List<TSystemMenus>>(tData);

            return new ApiResult()
            {
                Data = dataList,
                IsSuccess = true,

            };

        }

        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <param name="users"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost(Name = "AddSystemMenus")]
        public ApiResult AddSystemMenus(TSystemMenus menu)
        {

            _dataService.Add<TSystemMenus>(menu);

            var data = _dataService.Get<TSystemMenus>();

            return new ApiResult()
            {
                Data = data,
                IsSuccess = true,

            };

        }
    }
}
