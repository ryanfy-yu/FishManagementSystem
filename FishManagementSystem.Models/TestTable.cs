using System;
using System.Linq;
using System.Text;
using SqlSugar;

namespace FishManagementSystem.Models
{
    ///<summary>
    ///
    ///</summary>
    [SugarTable("testTable")]
    public partial class TestTable
    {
           public TestTable(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           [SugarColumn(IsPrimaryKey=true)]
           public byte[] id {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string name {get;set;} = null!;

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public int age {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public byte gender {get;set;}

    }
}
