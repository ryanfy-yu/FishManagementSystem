using Microsoft.Extensions.Configuration.Json;

namespace FishManagementSystem.Server.Utils
{
    public class AppsettingService
    {
        public static IConfiguration Configuration { get; private set; }

        public static string DbConnectionString { get; set; }
        static AppsettingService()
        {
            //ReloadOnChange = true 当appsettings.json被修改时重新加载            
            Configuration = new ConfigurationBuilder()
            //.SetBasePath(Directory.GetCurrentDirectory())
            //AppDomain.CurrentDomain.BaseDirectory是程序集基目录，所以appsettings.json,需要复制一份放在程序集目录下，
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
            .Build();

            DbConnectionString = Configuration.GetConnectionString("FishDB") ?? string.Empty;


        }


    }
}
