using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishManagementSystem.DBModels.Utils
{
    public static class AppConfigUtils
    {
        public static string DbConnectionString { get; set; }


         static AppConfigUtils() {

            DbConnectionString = AppConfigurtaionServices.Configuration.GetConnectionString("FishDB");
        }

        


    }
}
