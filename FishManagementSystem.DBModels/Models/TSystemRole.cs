using FishManagementSystem.DBModels.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishManagementSystem.DBModels.Models
{
    public class TSystemRole : ModelBase
    {
        public string RoleName { get; set; }

        public int? Status { get; set; }



    }
}
