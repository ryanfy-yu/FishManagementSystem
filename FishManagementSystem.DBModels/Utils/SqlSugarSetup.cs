using FishManagementSystem.DBModels.Models;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DbType = SqlSugar.DbType;

namespace FishManagementSystem.DBModels.Utils
{
    public class SqlSugarSetup
    {
        private ISqlSugarClient sugarDB;

        public SqlSugarSetup(string dbConnectionString)
        {

            sugarDB = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = dbConnectionString,
                DbType = DbType.MySql,
                IsAutoCloseConnection = true
            },
            db =>
            {
                db.Aop.OnLogExecuting = (sql, pars) =>
                {

                    //获取原生SQL推荐 5.1.4.63  性能OK
                    Console.WriteLine(UtilMethods.GetNativeSql(sql, pars));

                    //获取无参数化SQL 对性能有影响，特别大的SQL参数多的，调试使用 
                    //Console.WriteLine(UtilMethods.GetSqlString(DbType.SqlServer,sql,pars))
                };

                //注意多租户 有几个设置几个
                //db.GetConnection(i).Aop

            });

        }


        public ISqlSugarClient getDB()
        {
            return sugarDB;
        }

        internal bool CreatDB()
        {
            //建库
            return sugarDB.DbMaintenance.CreateDatabase();//达梦和Oracle不支持建库

        }

        internal bool CreatTables(string folderName)
        {
            //命名空间过滤，当然你也可以写其他条件过滤
            Type[] types = typeof(SqlSugarSetup).Assembly.GetTypes().Where(it => it.FullName.Contains("." + folderName)).ToArray();
            sugarDB.CodeFirst.SetStringDefaultLength(200).InitTables(types);//根据types创建表

            return true;
        }

    }
}