using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using restbe.Models;

namespace restbe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NBAPlayerController : ControllerBase
    {
        private readonly MainDbContext _context;

        public NBAPlayerController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/NBAPlayer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NBAPlayer>>> GetNBAPlayer()
        {
            return await _context.NBAPlayer.ToListAsync();
        }

        // GET: api/NBAPlayer/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NBAPlayer>> GetNBAPlayer(int id)
        {
            var nBAPlayer = await _context.NBAPlayer.FindAsync(id);

            if (nBAPlayer == null)
            {
                return NotFound();
            }

            return nBAPlayer;
        }

        // PUT: api/NBAPlayer/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNBAPlayer(int id, NBAPlayer nBAPlayer)
        {
            if (id != nBAPlayer.Id)
            {
                return BadRequest();
            }

            _context.Entry(nBAPlayer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NBAPlayerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/NBAPlayer
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NBAPlayer>> PostNBAPlayer(NBAPlayer nBAPlayer)
        {
            _context.NBAPlayer.Add(nBAPlayer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNBAPlayer", new { id = nBAPlayer.Id }, nBAPlayer);
        }

        // DELETE: api/NBAPlayer/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NBAPlayer>> DeleteNBAPlayer(int id)
        {
            var nBAPlayer = await _context.NBAPlayer.FindAsync(id);
            if (nBAPlayer == null)
            {
                return NotFound();
            }

            _context.NBAPlayer.Remove(nBAPlayer);
            await _context.SaveChangesAsync();

            return nBAPlayer;
        }

        private bool NBAPlayerExists(int id)
        {
            return _context.NBAPlayer.Any(e => e.Id == id);
        }
    }
}
