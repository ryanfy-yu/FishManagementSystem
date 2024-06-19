using AutoMapper;
using FishManagementSystem.Commons;
using FishManagementSystem.DBModels.Models;
using FishManagementSystem.DTO;
using FishManagementSystem.IBussinessService;
using FishManagementSystem.Mapping;
using FishManagementSystem.Server.Utils;
using FishManagementSystem.Swagger;
using Microsoft.AspNetCore.Mvc;

namespace FishManagementSystem.Server.Controllers.User
{
    /// <summary>
    /// 系统用户
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SystemUserController : FishControllerBase
    {
        public readonly ISystemUsersDataService _dataService;


        public SystemUserController(ISystemUsersDataService dataService, IMapper mapper, ILogger<SystemUserController> logger) : base(logger, mapper)
        {
            _dataService = dataService;

        }



        /// <summary>
        /// GetSystemUsers
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "GetSystemUsers")]
        [ApiExplorerSettings(GroupName = nameof(ApiVersion.v1))]
        public ApiResult GetSystemUserList()
        {
            //_logger.LogInformation("i am here");
            var data = _dataService.GetSystemUserInfoList();

            var dtoData = _mapper.Map<List<SystemUsersDTO>>(data);

            return new ApiResult()
            {
                Data = dtoData,
                IsSuccess = true,

            };

        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="users"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost(Name = "AddSystemUser")]
        public ApiResult AddSystemUser(string users, string password)
        {
            _dataService.AddSystemUserInfo(users, password);


            var data = _dataService.GetSystemUserInfoList();

            var dtoData = _mapper.Map<List<SystemUsersDTO>>(data);

            return new ApiResult()
            {
                Data = dtoData,
                IsSuccess = true,

            };

        }


    }
}
