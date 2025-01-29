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

        //  EXTRA for testing
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEventById(long id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return NotFound();
            return Ok(ev);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _context.Events.ToListAsync();
            return Ok(events);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(long id, [FromBody] Event updatedEvent)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return NotFound();

            ev.Type = updatedEvent.Type;
            ev.CreatedAt = updatedEvent.CreatedAt;

            _context.Events.Update(ev);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(long id)
        {
            var ev = await _context.Events.FindAsync(id);
            if (ev == null) return NotFound();

            _context.Events.Remove(ev);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
