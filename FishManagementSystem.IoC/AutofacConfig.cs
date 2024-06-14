using Autofac;
using Autofac.Extras.DynamicProxy;
using FishManagementSystem.BusinessService;
using FishManagementSystem.IBussinessService;


namespace FishManagementSystem.IoC
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SystemUsersService>().As<ISystemUsersService>();

            builder.RegisterType<DataService>().As<IDataService>().EnableInterfaceInterceptors();
        }




    }
}
