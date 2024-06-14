using Autofac.Extras.DynamicProxy;
using FishManagementSystem.IBussinessService;

namespace FishManagementSystem.BusinessService
{

    public class SystemUsersService : DataService, IDataService, ISystemUsersService
    {
        public SystemUsersService()
        {

        }
    }
}
