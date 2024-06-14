using Autofac;
using Autofac.Extras.DynamicProxy;
using FishManagementSystem.BusinessService;
using FishManagementSystem.IBussinessService;
using Microsoft.Extensions.Configuration;


namespace FishManagementSystem.IoC
{
    public class AutofacBusinessModule : Module
    {
        IConfigurationManager _config;


        public AutofacBusinessModule(IConfigurationManager config)
        {
            _config = config;
        }


        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SystemUsersDataService>().As<ISystemUsersDataService>().WithParameter("dbConnectionString", _config.GetConnectionString("FishDB") ?? string.Empty);

            //builder.RegisterType<DataService>().As<IDataService>().EnableInterfaceInterceptors();

            builder.RegisterType<BaseDataService>().As<IBaseDataService>().WithParameter("dbConnectionString", _config.GetConnectionString("FishDB") ?? string.Empty);
        }




    }
}
