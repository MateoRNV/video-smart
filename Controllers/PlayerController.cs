using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoSmartApi.data;
using VideoSmartApi.Models;

namespace VideoSmartApi.Controllers
{
    [Route("api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlayerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlayerById(Guid id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null) return NotFound();
            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer([FromBody] Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPlayerById), new { id = player.Id }, player);
        }

        // EXTRA for tests
        [HttpGet]
        public async Task<IActionResult> GetAllPlayers()
        {
            var players = await _context.Players.ToListAsync();
            return Ok(players);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayer(Guid id, [FromBody] Player updatedPlayer)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null) return NotFound();

            player.IsActive = updatedPlayer.IsActive;
            player.IsTracked = updatedPlayer.IsTracked;
            player.UpdatedAt = DateTime.UtcNow;
            player.UpdatedBy = updatedPlayer.UpdatedBy;

            _context.Players.Update(player);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(Guid id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null) return NotFound();

            _context.Players.Remove(player);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
