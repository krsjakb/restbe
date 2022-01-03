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
    public class SoundcardsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public SoundcardsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/Soundcards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Soundcard>>> GetSoundcard()
        {
            return await _context.Soundcard.ToListAsync();
        }

        // GET: api/Soundcards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Soundcard>> GetSoundcard(int id)
        {
            var soundcard = await _context.Soundcard.FindAsync(id);

            if (soundcard == null)
            {
                return NotFound();
            }

            return soundcard;
        }

        // PUT: api/Soundcards/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSoundcard(int id, Soundcard soundcard)
        {
            if (id != soundcard.Id)
            {
                return BadRequest();
            }

            _context.Entry(soundcard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoundcardExists(id))
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

        // POST: api/Soundcards
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Soundcard>> PostSoundcard(Soundcard soundcard)
        {
            _context.Soundcard.Add(soundcard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSoundcard", new { id = soundcard.Id }, soundcard);
        }

        // DELETE: api/Soundcards/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Soundcard>> DeleteSoundcard(int id)
        {
            var soundcard = await _context.Soundcard.FindAsync(id);
            if (soundcard == null)
            {
                return NotFound();
            }

            _context.Soundcard.Remove(soundcard);
            await _context.SaveChangesAsync();

            return soundcard;
        }

        private bool SoundcardExists(int id)
        {
            return _context.Soundcard.Any(e => e.Id == id);
        }
    }
}
