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
        private HttpClient httpClient;
        public RestServices()
        {
            httpClient = new HttpClient();
        }
        public async Task<Equipment> GetEquipment(string id)
        {
            var response = await httpClient.GetStringAsync($"{URL}/{id}");
            return JsonConvert.DeserializeObject<Equipment>(response);
        }

        public async Task<List<EquipmentViewModel>> GetEquipments()
        {
            List<EquipmentViewModel> equipmentViewModels = new List<EquipmentViewModel>();
            var response = await httpClient.GetStringAsync(URL);

            var equipments = JsonConvert.DeserializeObject<List<Equipment>>(response);

            foreach (var item in equipments)
            {
                var equipmentVM = new EquipmentViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Type = new EquipmentType()
                    {
                        Id = item.Type,
                        TypeName = item.TypeName
                    },

                    Status = new EquipmentStatus()
                    {
                        Id = item.Status,
                        StatusName = item.StatusName
                    },

                    Quantity = item.Quantity
                };
                equipmentViewModels.Add(equipmentVM);
            }

            return equipmentViewModels;
        }

        public async Task<bool> PostEquipment(EquipmentPost equipment)
        {
            var json = JsonConvert.SerializeObject(equipment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(URL, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<EquipmentViewModel>> SearchEquipment(string name)
        {
            List<EquipmentViewModel> equipmentViewModels = new List<EquipmentViewModel>();

            var response = await httpClient.GetAsync($"{URL}/search?name={name}");

            if((int)response.StatusCode == 200)
            {
                var body = await httpClient.GetStringAsync($"{URL}/search?name={name}");
                var equipments = JsonConvert.DeserializeObject<List<Equipment>>(body);

                foreach (var item in equipments)
                {
                    var equipmentVM = new EquipmentViewModel()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Type = new Models.EquipmentType()
                        {
                            Id = item.Type,
                            TypeName = item.TypeName
                        },
                        Quantity = item.Quantity
                    };
                    equipmentViewModels.Add(equipmentVM);
                }
                return equipmentViewModels;
            }
            else
            {
                return equipmentViewModels;
            }
        }

        public async Task<bool> DeleteEquipment(string id)
        {
            var response = await httpClient.DeleteAsync($"{URL}/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateEquipment(EquipmentUpdate equipment)
        {
            var json = JsonConvert.SerializeObject(equipment);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync($"{URL}/{equipment.Id}", content);
            return response.IsSuccessStatusCode;
        }
    }
}
