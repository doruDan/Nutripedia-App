using System.Net.Http.Json;
using FoodAppV1.Models;

namespace FoodAppV1.Services
{
    public class FoodService : IFoodService
    {
        public readonly IHttpClientFactory _clientFactory;

        public FoodService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<FoodModel> GetFoodInfo(string foodname)
        {
            FoodModel foodInfo = null;
            string errorString;

            var client = _clientFactory.CreateClient("meta");
            string requestUrl = client.BaseAddress + $"&query={foodname}";

            try
            {
                foodInfo = await client.GetFromJsonAsync<FoodModel>(requestUrl);
                errorString = null;
            }
            catch (Exception ex) 
            {
                errorString = $"There was an error finding information about your food: {ex.Message}";
            }

            return foodInfo;
        }
    }
}
