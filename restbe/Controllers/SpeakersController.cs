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
    public class SpeakersController : ControllerBase
    {
        private readonly MainDbContext _context;

        public SpeakersController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/Speakers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Speaker>>> GetSpeaker()
        {
            return await _context.Speaker.ToListAsync();
        }

        // GET: api/Speakers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Speaker>> GetSpeaker(int id)
        {
            var speaker = await _context.Speaker.FindAsync(id);

            if (speaker == null)
            {
                return NotFound();
            }

            return speaker;
        }

        // PUT: api/Speakers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpeaker(int id, Speaker speaker)
        {
            if (id != speaker.Id)
            {
                return BadRequest();
            }

            _context.Entry(speaker).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpeakerExists(id))
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

        // POST: api/Speakers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Speaker>> PostSpeaker(Speaker speaker)
        {
            _context.Speaker.Add(speaker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpeaker", new { id = speaker.Id }, speaker);
        }

        // DELETE: api/Speakers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Speaker>> DeleteSpeaker(int id)
        {
            var speaker = await _context.Speaker.FindAsync(id);
            if (speaker == null)
            {
                return NotFound();
            }

            _context.Speaker.Remove(speaker);
            await _context.SaveChangesAsync();

            return speaker;
        }

        private bool SpeakerExists(int id)
        {
            return _context.Speaker.Any(e => e.Id == id);
        }
    }
}
