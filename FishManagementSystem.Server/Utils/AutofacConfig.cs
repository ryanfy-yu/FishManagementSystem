using Autofac.Extensions.DependencyInjection;
using Autofac;
using FishManagementSystem.BusinessService;
using FishManagementSystem.IBussinessService;
using System.Configuration;
using Castle.DynamicProxy;
using Autofac.Extras.DynamicProxy;

namespace FishManagementSystem.Server.Utils
{
    public static class AutofacConfig
    {


        public static void AutofacRegister(this ConfigureHostBuilder host)
        {


            host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            host.ConfigureContainer<ContainerBuilder>(o =>
            {
                //注册ioc
                // o.RegisterType<DataService>().As<IDataService>();
               // o.RegisterType<LogInterceptor>();

                o.RegisterType<DataService>().As<IDataService>().EnableInterfaceInterceptors();

                //o.Register(o => new DataService(AppsettingService.DbConnectionString)).InterceptedBy(typeof(IDataService)).EnableInterfaceInterceptors();




            });

        }

    }
}
