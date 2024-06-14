using FishManagementSystem.DBModels.Models;
using FishManagementSystem.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishManagementSystem.IBussinessService
{
    public interface ISystemUsersDataService : IBaseDataService
    {

        public TSystemUsers GetSystemUserInfo(string userid);
        

    }
}
