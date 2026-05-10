using FoodAppV1.Models;

namespace FoodAppV1.Services
{
    public interface IFoodService
    {
        Task<FoodModel> GetFoodInfo(string foodname);
    }
}
