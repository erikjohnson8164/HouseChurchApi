using HouseChurchApi.Dtos;
using HouseChurchApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HouseChurchApi.Interfaces
{
    public interface IEventsRepository
    {
        Task<List<EventDto>> GetAllEvents();
        Task<bool> DeleteEvent(int id);
        Task<Event> AddEvent(Event newEvent);
    }

}

