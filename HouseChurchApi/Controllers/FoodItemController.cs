using HouseChurchApi.Models;
using Microsoft.AspNetCore.Mvc;
using HouseChurchApi.Interfaces;
using HouseChurchApi.RepositoryClasses;


namespace HouseChurchApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemsController : ControllerBase
    {
        private readonly IFoodItemRepository _foodItemRepository;

        public FoodItemsController(IFoodItemRepository foodItemRepository)
        {
            _foodItemRepository = foodItemRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodItem>>> GetFoodItems()
        {
            var foodItems = await _foodItemRepository.GetAllFoodItems();
            return Ok(foodItems);
        }

        [HttpPost]
        public async Task<ActionResult<FoodItem>> CreateFoodItem(FoodItem foodItem)
        {
            var createdFoodItem = await _foodItemRepository.AddFoodItem(foodItem);
            return CreatedAtAction(nameof(GetFoodItems), new { id = createdFoodItem.Id }, createdFoodItem);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFoodItem(int id)
        {
            await _foodItemRepository.DeleteFoodItem(id);
            return NoContent(); // 204 on successful deletion
        }
    }
}

