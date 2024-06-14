using FishManagementSystem.DBModels.Utils;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishManagementSystem.DBModels.Models
{
    public class TStudent : ModelBase
    {

        public int? SchoolId { get; set; }
        public string? Name { get; set; }
    }
}
