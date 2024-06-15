using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishManagementSystem.DBModels.Models
{
    public class TSystemMenus
    {
        public string ParentId { get; set; }

        public string MenuName { get; set; }

        public int MenuType { get; set; }

        public string Icon { get; set; }

        public string Url { get; set; }

        public int Sort { get; set; }

        public int Status { get; set; }


    }
}
