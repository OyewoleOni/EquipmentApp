using EquipmentApp.Interfaces;
using EquipmentApp.Models;
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
        public async Task<Equipment> GetEquipment(string id)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync($"http://etestapi.test.eminenttechnology.com/api/Equipment/{id}");
            return JsonConvert.DeserializeObject<Equipment>(response);
        }

        public  async Task<List<Equipment>> GetEquipments()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("http://etestapi.test.eminenttechnology.com/api/Equipment");
            return JsonConvert.DeserializeObject<List<Equipment>>(response);
        }

        public Task<bool> PostEquipment(Equipment equipment)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Equipment>> SearchEquipment(string name)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync($"http://etestapi.test.eminenttechnology.com/api/Equipment/search?name={name}&status=1&type=1");
            return JsonConvert.DeserializeObject<List<Equipment>>(response);
        }
    }
}
