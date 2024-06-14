using AutoMapper;
using FishManagementSystem.IBussinessService;
using FishManagementSystem.Server.Controllers;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace FishManagementSystem.Server.Utils
{
    public class FishControllerBase : ControllerBase
    {

        protected readonly ILogger<dynamic> _logger;
        protected readonly IMapper _mapper;


        public FishControllerBase(ILogger<dynamic> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;

        }
    }
}
