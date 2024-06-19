using Autofac.Extras.DynamicProxy;
using FishManagementSystem.DBModels.Models;
using FishManagementSystem.DBModels.Utils;
using FishManagementSystem.IBussinessService;
using FishManagementSystem.Mapping;
using SqlSugar;

namespace FishManagementSystem.BusinessService
{

    public class SystemUsersDataService : DataService, ISystemUsersDataService
    {


        public SystemUsersDataService(string dbConnectionString) : base(dbConnectionString) { }

        public bool AddSystemUserInfo(string username, string pwd)
        {
            return this.Add<TSystemUsers>(new TSystemUsers
            {
                Username = username,
                Password = pwd

            });
        }

        public TSystemUsers GetSystemUserInfo(string userid)
        {
            return _db.Queryable<TSystemUsers>().Where(it => it.Id == userid && it.IsDeleted != true).First();


        }

        public List<TSystemUsers> GetSystemUserInfoList()
        {
            return _db.Queryable<TSystemUsers>().Where(o => o.IsDeleted != true).ToList();
        }
    }
}