using System;
using System.Collections.Generic;
using System.Text;

namespace EquipmentApp.Data
{
    public static class PopulateData
    {
        public static List<EquipmentApp.Models.Type> GetTypes()
        {
            List<EquipmentApp.Models.Type> types = new List<EquipmentApp.Models.Type>()
            {
                new Models.Type()
                {
                    Id = 1,
                    TypeName = "Indoor"
                },
                 new Models.Type()
                {
                    Id = 2,
                    TypeName = "Outdoor"
                }
            };
            return types;
            
        }
    }
}
