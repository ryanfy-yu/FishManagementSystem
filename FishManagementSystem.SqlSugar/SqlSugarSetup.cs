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

namespace FishManagementSystem.SqlSugar
{
    public class SqlSugarSetup
    {
        private SqlSugarClient db;

        public SqlSugarSetup(string? connectionString)
        {


            string sqlconn = connectionString ?? ConfigurationManager.ConnectionStrings["fishDB"].ConnectionString;


            db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = sqlconn,
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


        public SqlSugarClient getDB()
        {
            return db;

        }
    }
}