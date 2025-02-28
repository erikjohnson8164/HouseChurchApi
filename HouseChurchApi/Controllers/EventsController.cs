using HouseChurchApi.Models;
using Microsoft.AspNetCore.Mvc;
using HouseChurchApi.Interfaces;


namespace HouseChurchApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventsRepository _eventsRepository;
        public EventsController(IEventsRepository eventsRepository) 
        {
            _eventsRepository = eventsRepository; 
        }
        [HttpGet]
        public async Task<IActionResult> GetEvents()
        {
            var events = await _eventsRepository.GetAllEvents();
            return Ok(events);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            await _eventsRepository.DeleteEvent(id);
            return NoContent(); // 204 on successful deletion
        }
        [HttpPost]
        public async Task<IActionResult> AddEvent([FromBody] Event newEvent)
        {
            await _eventsRepository.AddEvent(newEvent);
            return CreatedAtAction(nameof(GetEvents), new { id = newEvent.Id }, newEvent);
        }
    }
}
