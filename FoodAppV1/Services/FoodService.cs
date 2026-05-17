using FoodAppV1.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Net.Http.Json;
using System.Text.Json;

namespace FoodAppV1.Services
{
    public class FoodService : IFoodService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _config;

        public FoodService(IHttpClientFactory clientFactory, IConfiguration config)
        {
            _clientFactory = clientFactory;
            _config = config;
        }

        public async Task<Food> GetFoodInfo(string foodname)
        {
            var client = _clientFactory.CreateClient("meta");
            var APIKey = _config.GetValue<string>("APIKey");

            string requestUrl = client.BaseAddress.ToString() + "search?api_key=" + APIKey + "&query=" + Uri.EscapeDataString(foodname);

            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                var foodInfo = await client.GetFromJsonAsync<FoodModel>(requestUrl);
                return foodInfo?.foods.FirstOrDefault();
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"[FoodService Error] {ex.GetType().Name}: {ex.Message}");
                return null;
            }
        }
    }
}
