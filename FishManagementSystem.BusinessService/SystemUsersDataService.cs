using Autofac.Extras.DynamicProxy;
using FishManagementSystem.DBModels.Models;
using FishManagementSystem.DBModels.Utils;
using FishManagementSystem.IBussinessService;
using FishManagementSystem.Mapping;
using SqlSugar;

namespace FishManagementSystem.BusinessService
{

    public class SystemUsersDataService : BaseDataService, IBaseDataService, ISystemUsersDataService
    {


        public SystemUsersDataService(string dbConnectionString) : base(dbConnectionString)
        {

        }


        public TSystemUsers GetSystemUserInfo(string userid)
        {
            return _db.Queryable<TSystemUsers>().Where(it => it.Id == userid && it.IsDeleted != true).First();


        }
    }
}