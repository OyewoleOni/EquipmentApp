using EquipmentApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentApp.Interfaces
{
    interface IRestServices
    {
        Task<List<Equipment>> GetEquipments();
        Task<Equipment> GetEquipment(string id);
        Task<List<Equipment>> SearchEquipment(string name);
        Task<bool> PostEquipment(Equipment equipment);
    }
}
