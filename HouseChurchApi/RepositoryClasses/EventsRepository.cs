using HouseChurchApi.Contexts;
using HouseChurchApi.Dtos;
using HouseChurchApi.Interfaces;
using HouseChurchApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseChurchApi.RepositoryClasses
{
    public class EventsRepository : IEventsRepository
    {
        private readonly ChurchDbContext _churchDbContext;
        public EventsRepository(ChurchDbContext churchDbContext)
        {
            _churchDbContext = churchDbContext;
        }
        public async Task<List<EventDto>> GetAllEvents()
        {
            return await _churchDbContext.Events
                .Include(e => e.FoodItems)
                .Select(e => new EventDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Date = e.Date,
                    Location = e.Location,
                    FoodItems = e.FoodItems.Select(f => new FoodItemDto
                    {
                        Id = f.Id,
                        Item = f.Item,
                        BroughtBy = f.BroughtBy,
                        EventId = f.EventId
                    }).ToList()
                })
                .ToListAsync();
        }
        public async Task<bool> DeleteEvent(int id)
        {
            var eventToDelete = await _churchDbContext.Events.FindAsync(id);
            if (eventToDelete == null)
            {
                return false; // Event not found
            }
            _churchDbContext.Events.Remove(eventToDelete);
            await _churchDbContext.SaveChangesAsync();
            return true; // Successfully deleted
        }
        public async Task<Event> AddEvent(Event newEvent)
        {
            _churchDbContext.Events.Add(newEvent);
            await _churchDbContext.SaveChangesAsync();
            return newEvent;
        }
    }
}
