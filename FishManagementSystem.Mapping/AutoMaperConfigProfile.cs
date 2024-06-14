using AutoMapper;
using FishManagementSystem.DBModels.Models;
using FishManagementSystem.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishManagementSystem.Mapping
{

    /// <summary>
    /// 系统用户
    /// </summary>
    public class AutoMaperConfigProfile : Profile
    {
        public AutoMaperConfigProfile()
        {

            // Mapping
            CreateMap<TSystemUsers, SystemUsersDTO>().ReverseMap();



        }

    }
}
