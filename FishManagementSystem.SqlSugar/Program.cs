// See https://aka.ms/new-console-template for more information
using FishManagementSystem.Models;
using FishManagementSystem.SqlSugar;

string modelpath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + "/FishManagementSystem.Models";

//string sqlconn = connectionString ?? ConfigurationManager.ConnectionStrings["fishDB"].ConnectionString;

SqlSugarSetup dbSetup = new(null);


//生成model实体,首字母大写
dbSetup.getDB().DbFirst.IsCreateAttribute().StringNullable().FormatClassName(it => char.ToUpper(it[0]) + it.Substring(1)).CreateClassFile(modelpath, "FishManagementSystem.Models");

