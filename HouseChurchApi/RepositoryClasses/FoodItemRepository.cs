using HouseChurchApi.Contexts;
using HouseChurchApi.Interfaces;
using HouseChurchApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseChurchApi.RepositoryClasses
{
    public class FoodItemRepository : IFoodItemRepository
    {
        private readonly ChurchDbContext _context;

        // Constructor to inject the DbContext
        public FoodItemRepository(ChurchDbContext context)
        {
            _context = context;
        }

        public async Task<FoodItem> AddFoodItem(FoodItem newFoodItem)
        {
            // Add the new FoodItem to the DbSet
            _context.FoodItems.Add(newFoodItem);

            // Save changes to the database
            await _context.SaveChangesAsync();

            // Return the added FoodItem (includes the generated Id)
            return newFoodItem;
        }

        public async Task<bool> DeleteFoodItem(int id)
        {
            // Find the FoodItem by Id
            var foodItem = await _context.FoodItems.FindAsync(id);

            if (foodItem == null)
            {
                // Return false if the item doesn't exist
                return false;
            }

            // Remove the FoodItem from the DbSet
            _context.FoodItems.Remove(foodItem);

            // Save changes and return true if successful (affected rows > 0)
            var rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<List<FoodItem>> GetAllFoodItems()
        {
            // Retrieve all FoodItems, including their related Event data
            return await _context.FoodItems
                .ToListAsync();
        }
    }
}
