using EquipmentApp.Models;
using EquipmentApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentApp.Interfaces
{
    public  interface IRestServices
    {
        Task<List<EquipmentViewModel>> GetEquipments();
        Task<Equipment> GetEquipment(string id);
        Task<List<EquipmentViewModel>> SearchEquipment(string name);
        Task<bool> PostEquipment(EquipmentPost equipment);
        Task<bool> DeleteEquipment(string id);
    }
}
