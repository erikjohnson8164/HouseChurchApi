using HouseChurchApi.Contexts;
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
        public async Task<List<Event>> GetAllEvents()
        {
            var events = await _churchDbContext.Events.ToListAsync();
            return events;
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
