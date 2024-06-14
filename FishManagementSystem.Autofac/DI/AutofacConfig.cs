using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Autofac.Extras.DynamicProxy;
using FishManagementSystem.BusinessService;
using FishManagementSystem.IBussinessService;

namespace FishManagementSystem.Autofac.DI
{
    public class AutofacConfig : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SystemUsersService>().As<ISystemUsersService>();

            builder.RegisterType<DataService>().As<IDataService>().EnableInterfaceInterceptors();
        }




    }
}
