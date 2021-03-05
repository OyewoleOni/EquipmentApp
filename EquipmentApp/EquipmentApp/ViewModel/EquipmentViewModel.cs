using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentApp.ViewModel
{
    public class EquipmentViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        //public int Status { get; set; }
        //public string StatusName { get; set; }

        public EquipmentApp.Models.EquipmentStatus Status { get; set; }
        public int Quantity { get; set; }
        public EquipmentApp.Models.EquipmentType Type { get; set; }
    }
}
