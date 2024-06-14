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
        [SugarColumn(IsPrimaryKey = true)]
        public new string Id { get; set; } = Guid.NewGuid().ToString();

        public new DateTime CreateDate { get; set; } = DateTime.Now;

        public new DateTime UpdateDate { get; set; } = DateTime.Now;

        public new bool IsDeleted { get; set; } = false;

    }
}
