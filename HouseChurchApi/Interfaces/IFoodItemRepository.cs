using HouseChurchApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HouseChurchApi.Interfaces
{
    public interface IFoodItemRepository
    {
        Task<List<FoodItem>> GetAllFoodItems();
        Task<bool> DeleteFoodItem(int id);
        Task<FoodItem> AddFoodItem(FoodItem newFoodItem);
    }

}

