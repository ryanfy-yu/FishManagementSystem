using FishManagementSystem.SqlSugar;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace FishManagementSystem.DLL
{
    public class LogsDLL:IDLL
    {
        private readonly IConfiguration conf;


        private Logs()
        {
            var ConnectionStrings = conf["ConnectionStrings:FishDBConnection"];
            SqlsugarSetup dbSetup = new SqlsugarSetup(ConnectionStrings);

        }


        public List<Logs> GetDetails()
        {



        }


    }
}
