using FishManagementSystem.DBModels.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishManagementSystem.DBModels.Models
{
    public class TSystemUserRoleMap : ModelBase
    {
        public string UserId { get; set; }

        public string RoleId { get; set; }

        public int? Status { get; set; }



    }
}
