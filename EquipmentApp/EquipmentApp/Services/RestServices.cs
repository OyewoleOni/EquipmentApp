using EquipmentApp.Interfaces;
using EquipmentApp.Models;
using EquipmentApp.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentApp.Services
{
    public class RestServices : IRestServices
    {
        private string URL = "http://etestapi.test.eminenttechnology.com/api/Equipment";
        public async Task<Equipment> GetEquipment(string id)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync($"{URL}/{id}");
            return JsonConvert.DeserializeObject<Equipment>(response);
        }

        //public  async Task<List<Equipment>> GetEquipments()
        //{
        //    List<EquipmentViewModel> equipmentViewModels = new List<EquipmentViewModel>();
        //    var httpClient = new HttpClient();
        //    var response = await httpClient.GetStringAsync("http://etestapi.test.eminenttechnology.com/api/Equipment");

        //   var equipments = JsonConvert.DeserializeObject<List<Equipment>>(response);

        //    foreach (var item in equipments)
        //    {
        //        var equipmentVM = new EquipmentViewModel()
        //        {
        //            Id = item.Id,
        //            Name = item.Name,
        //            Type = new Models.Type()
        //            {
        //                Id = item.Type,
        //                TypeName = item.TypeName
        //            }
        //        };
        //    }

        //    return JsonConvert.DeserializeObject<List<Equipment>>(response);
        //}

        public async Task<List<EquipmentViewModel>> GetEquipments()
        {
            List<EquipmentViewModel> equipmentViewModels = new List<EquipmentViewModel>();
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(URL);

            var equipments = JsonConvert.DeserializeObject<List<Equipment>>(response);

            foreach (var item in equipments)
            {
                var equipmentVM = new EquipmentViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Type = new Models.Type()
                    {
                        Id = item.Type,
                        TypeName = item.TypeName
                    }
                };
                equipmentViewModels.Add(equipmentVM);
            }

            return equipmentViewModels;
        }

        public async Task<bool> PostEquipment(EquipmentPost equipment)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(equipment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(URL, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<Equipment>> SearchEquipment(string name)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync($"{URL}/search?name={name}&status=1&type=1");
            return JsonConvert.DeserializeObject<List<Equipment>>(response);
        }
    }
}
