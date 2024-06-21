using FishManagementSystem.IDBModels;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishManagementSystem.DBModels.Utils
{
    public abstract class ModelBase : IModel
    {
        //数据是自增需要加上IsIdentity 
        //数据库是主键需要加上IsPrimaryKey 
        //注意：要完全和数据库一致2个属性
        [SugarColumn(IsPrimaryKey = true, DefaultValue = "UUID()", IsOnlyIgnoreInsert = true)]

        public string Id { get; set; }

        [SugarColumn(DefaultValue = "NOW()", IsOnlyIgnoreInsert = true)]
        public DateTime CreateDate { get; set; }

        [SugarColumn(DefaultValue = "NOW()", IsOnlyIgnoreInsert = true)]
        public DateTime UpdateDate { get; set; } = DateTime.Now;

        public virtual bool IsDeleted { get; set; } = false;

    }
}
