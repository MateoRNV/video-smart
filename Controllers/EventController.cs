using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoSmartApi.data;
using VideoSmartApi.Models;

namespace VideoSmartApi.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent([FromBody] Event newEvent)
        {
            if (!await _context.Sessions.AnyAsync(s => s.Id == newEvent.SessionId))
            {
                return BadRequest("Session not found.");
            }

            _context.Events.Add(newEvent);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateEvent), new { id = newEvent.Id }, newEvent);
        }
    }
}
