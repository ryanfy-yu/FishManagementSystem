using AutoMapper;
using FishManagementSystem.Commons;
using FishManagementSystem.DBModels.Models;
using FishManagementSystem.IBussinessService;
using FishManagementSystem.JWT;
using FishManagementSystem.Swagger;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FishManagementSystem.SSO.Controllers
{
    /// <summary>
    /// 登录
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public readonly IDataService _dataService;
        public readonly ILogger<LoginController> _logger;
        public readonly IMapper _mapper;

        public readonly JwtToken _jwtToken;


        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="dataService"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public LoginController(IDataService dataService, ILogger<LoginController> logger, IMapper mapper, JwtToken jwtToken)
        {
            _dataService = dataService;
            _logger = logger;
            _mapper = mapper;
            _jwtToken = jwtToken;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="usernameOrEmail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        [ApiExplorerSettings(GroupName = nameof(ApiVersion.v1))]
        public ApiResult Post(string usernameOrEmail, string password)
        {


            var tData = _dataService.Get<TSystemUsers>(o => (o.Username == usernameOrEmail || o.Email == usernameOrEmail) && o.Password == password).FirstOrDefault();

            if (tData == null)
            {
                return new ApiResult()
                {

                    Message = "密码错误",
                    IsSuccess = false,
                };
            }


            string token = _jwtToken.CreateToken(tData.Username, new string[] { "username", "password" });

            return new ApiResult()
            {
                Message = "密码正确",
                IsSuccess = true,
                Data = token
            };

        }

    }
}
