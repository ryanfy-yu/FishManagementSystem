using AutoMapper;
using FishManagementSystem.Commons;
using FishManagementSystem.DBModels.Models;
using FishManagementSystem.DTO;
using FishManagementSystem.IBussinessService;
using FishManagementSystem.Swagger;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FishManagementSystem.SSO.Controllers
{
    /// <summary>
    /// 用户相关
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IDataService _dataService;
        public readonly ILogger<UserController> _logger;
        public readonly IMapper _mapper;


        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="dataService"></param>
        /// <param name="mapper"></param>
        /// <param name="logger"></param>
        public UserController(IDataService dataService, IMapper mapper, ILogger<UserController> logger)
        {
            _dataService = dataService;
            _logger = logger;
            _mapper = mapper;

        }

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <returns></returns>
        // POST api/<LoginController>
        [Authorize]
        [HttpGet]
        [ApiExplorerSettings(GroupName = nameof(ApiVersion.v1))]
        public ApiResult Get()
        {

            var tData = _dataService.Get<TSystemUsers>();


            var dataList = _mapper.Map<List<SystemUsersDTO>>(tData);

            return new ApiResult()
            {
                Data = dataList,
                IsSuccess = true,

            };

        }

    }
}
