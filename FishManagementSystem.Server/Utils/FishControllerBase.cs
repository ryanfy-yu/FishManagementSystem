using FishManagementSystem.SqlSugar;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace FishManagementSystem.Server.Utils
{
    public class FishControllerBase : ControllerBase
    {

        public SqlSugarClient db;

        public FishControllerBase() {
            string? connStr = AppConfigurtaionServices.Configuration.GetConnectionString("FishDB");
            db  = new SqlSugarSetup(connStr).getDB();

        }
    }
}
