using FishManagementSystem.DBModels.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishManagementSystem.DBModels.Models
{
    public class TSystemUserMenuMap : ModelBase
    {
        public string UserId { get; set; }

        public int MenuId { get; set; }

        public int? Status { get; set; }


    }
}
