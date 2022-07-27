using Microsoft.Data.SqlClient;
using SampleAppWeb.EntityFramework;
using SampleAppWeb.Uow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SampleAppWeb.Uow
{
    public class TouristRepository : ITouristRepository
    {
        protected readonly HttpClient _httpClient;
        
        public TouristRepository()
        {
            _httpClient = new HttpClient();
        }

        public async Task<AdequateShop> Get()
        {
            var streamTask = _httpClient.GetStreamAsync("http://restapi.adequateshop.com/api/Tourist?page=2");
            var tourist = await JsonSerializer.DeserializeAsync<AdequateShop>(await streamTask);
            return tourist;
        }

        public async Task<Tourist> GetById(int touristID)
        {
            var streamTask = await _httpClient.GetAsync($"http://restapi.adequateshop.com/api/Tourist/{touristID}");
            return new Tourist();
        }

        public async Task<Tourist> Insert(TouristAddRequest tourist)
        {
            var serializeTourist = JsonSerializer.Serialize(tourist);
            var message = new HttpRequestMessage()
            {
                Content = new StringContent(serializeTourist, Encoding.UTF8, "application/json")
            };

            var streamTask = await _httpClient.PostAsync("http://restapi.adequateshop.com/api/Tourist", message.Content);
            var resultContent = await streamTask.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Tourist>(resultContent);
        }

        public async Task<Tourist> Update(TouristEditRequest tourist)
        {
            var serializeTourist = JsonSerializer.Serialize(tourist);
            var message = new HttpRequestMessage()
            {
                Content = new StringContent(serializeTourist, Encoding.UTF8, "application/json")
            };
            var streamTask = await _httpClient.PutAsync($"http://restapi.adequateshop.com/api/Tourist/{tourist.Id}", message.Content);
            var resultContent = await streamTask.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Tourist>(resultContent);
        }

        public async Task<Tourist> Delete(int touristID)
        {
           
            var streamTask = await _httpClient.DeleteAsync($"http://restapi.adequateshop.com/api/Tourist/{touristID}");
            var resultContent = await streamTask.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Tourist>(resultContent);
        }

    }
}
