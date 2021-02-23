using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentApp.Data
{
    public static class PopulateData
    {
        public static List<EquipmentApp.Models.EquipmentType> GetTypes()
        {
            List<EquipmentApp.Models.EquipmentType> types = new List<EquipmentApp.Models.EquipmentType>()
            {
                new Models.EquipmentType()
                {
                    Id = 1,
                    TypeName = "Indoor"
                },
                 new Models.EquipmentType()
                {
                    Id = 2,
                    TypeName = "Outdoor"
                }
            };
            return types;
            
        }
    }
}
