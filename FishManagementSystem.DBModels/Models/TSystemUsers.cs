using FishManagementSystem.DBModels.Utils;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishManagementSystem.DBModels.Models
{

    /// <summary>
    /// 系统用户
    /// </summary>
    public class TSystemUsers : ModelBase
    {

        public string Username { get; set; }

        public string Password { get; set; }


        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }


    }
}
