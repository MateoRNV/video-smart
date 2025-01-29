using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoSmartApi.data;
using VideoSmartApi.Models;

namespace VideoSmartApi.Controllers
{
    [Route("api/sessions")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SessionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // EXTRA: In order to create sessions and events
        [HttpPost]
        public async Task<IActionResult> CreateSession([FromBody] Session session)
        {
            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSessionById), new { id = session.Id }, session);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSessionById(Guid id)
        {
            var session = await _context.Sessions.FindAsync(id);
            if (session == null) return NotFound();
            return Ok(session);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSessions()
        {
            var sessions = await _context.Sessions.ToListAsync();
            return Ok(sessions);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession(Guid id)
        {
            var session = await _context.Sessions.FindAsync(id);
            if (session == null) return NotFound();

            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
