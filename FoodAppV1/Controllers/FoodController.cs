using FoodAppV1.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodAppV1.Controllers
{
    public class FoodController : Controller
    {
        private readonly ILogger<FoodController> _logger;
        private readonly IFoodService _foodService;

        public FoodController(ILogger<FoodController> logger, IFoodService foodService)
        {
            _logger = logger;
            _foodService = foodService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FoodDataDisplay(string foodname)
        {
            var foodInformation = await _foodService.GetFoodInfo(foodname);
            return View(foodInformation);
        }
    }
}
