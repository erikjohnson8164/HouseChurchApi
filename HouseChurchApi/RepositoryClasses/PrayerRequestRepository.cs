using HouseChurchApi.Contexts;
using HouseChurchApi.Interfaces;
using HouseChurchApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseChurchApi.RepositoryClasses
{
    public class PrayerRequestRepository : IPrayerRequestRepository
    {
        private readonly ChurchDbContext _churchDbContext;
        public PrayerRequestRepository(ChurchDbContext churchDbContext)
        {
            _churchDbContext = churchDbContext;
        }
        public async Task<List<PrayerRequest>> GetPrayerRequests()
        {
            var prayerRequests = await _churchDbContext.PrayerRequests.ToListAsync();
            return prayerRequests;
        }
        public async Task<bool> DeletePrayerRequest(int id)
        {
            var prayerRequestToDelete = await _churchDbContext.PrayerRequests.FindAsync(id);
            if (prayerRequestToDelete == null)
            {
                return false; // Event not found
            }
            _churchDbContext.PrayerRequests.Remove(prayerRequestToDelete);
            await _churchDbContext.SaveChangesAsync();
            return true; // Successfully deleted
        }
        public async Task<PrayerRequest> AddPrayerRequest(PrayerRequest newPrayerRequest)
        {
            _churchDbContext.PrayerRequests.Add(newPrayerRequest);
            await _churchDbContext.SaveChangesAsync();
            return newPrayerRequest;
        }
    }
}
