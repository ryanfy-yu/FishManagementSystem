// See https://aka.ms/new-console-template for more information
using FishManagementSystem.DBModels.Utils;
using System.Configuration;
using System.Runtime.CompilerServices;

try
{
    //string? a = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace;

    string connstr = ConfigurationManager.ConnectionStrings["fishDB"].ConnectionString;

    SqlSugarSetup dbSetup = new(connstr);

    dbSetup.CreatDB();
    dbSetup.CreatTables("Models");


    //生成model实体,首字母大写
    //dbSetup.getDB().DbFirst.IsCreateAttribute().StringNullable().FormatClassName(it => char.ToUpper(it[0]) + it.Substring(1)).CreateClassFile(modelpath, "FishManagementSystem.DBModels");

}
catch (Exception ex)
{
    Console.WriteLine(ex);

}

