using HouseChurchApi.Models;
using Microsoft.AspNetCore.Mvc;
using HouseChurchApi.Interfaces;


namespace HouseChurchApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrayerRequestController : ControllerBase
    {
        private readonly IPrayerRequestRepository _prayerRequestRepository;
        public PrayerRequestController(IPrayerRequestRepository prayerRequestRepository)
        {
            _prayerRequestRepository = prayerRequestRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetPrayerRequest()
        {
            var events = await _prayerRequestRepository.GetPrayerRequests();
            return Ok(events);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrayerRequest(int id)
        {
            await _prayerRequestRepository.DeletePrayerRequest(id);
            return NoContent(); // 204 on successful deletion
        }
        [HttpPost]
        public async Task<IActionResult> AddPrayerRequest([FromBody] PrayerRequest newPrayerRequest)
        {
            await _prayerRequestRepository.AddPrayerRequest(newPrayerRequest);
            return CreatedAtAction(nameof(GetPrayerRequest), new { id = newPrayerRequest.Id }, newPrayerRequest);
        }
    }
}
