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
                },
                  new Models.EquipmentType()
                {
                    Id = 3,
                    TypeName = "Indoor/Outdoor"
                }

            };
            return types;

        }

        public static List<EquipmentApp.Models.EquipmentType> GetStatuses()
        {
            List<EquipmentApp.Models.EquipmentType> types = new List<EquipmentApp.Models.EquipmentType>()
            {
                new Models.EquipmentType()
                {
                    Id = 0,
                    TypeName = "In-Active"
                },
                 new Models.EquipmentType()
                {
                    Id = 1,
                    TypeName = "Active"
                }
            };
            return types;

        }
    }
}
