using HouseChurchApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HouseChurchApi.Interfaces
{
    public interface IPrayerRequestRepository
    {
        Task<List<PrayerRequest>> GetPrayerRequests();
        Task<bool> DeletePrayerRequest(int id);
        Task<PrayerRequest> AddPrayerRequest(PrayerRequest newPrayerRequest);
    }

}

