using FishManagementSystem.DBModels.Models;
using FishManagementSystem.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishManagementSystem.IBussinessService
{
    public interface ISystemUsersDataService : IDataService
    {

        public TSystemUsers GetSystemUserInfo(string userid);


        public List<TSystemUsers> GetSystemUserInfoList();


        public bool AddSystemUserInfo(string user,string pwd);

    }
}
