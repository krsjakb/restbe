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
    public class WitchesController : ControllerBase
    {
        private readonly MainDbContext _context;

        public WitchesController(MainDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Witches>>> GetWitch()
        {
            return await _context.Witches.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Witches>> GetWitc(int id)
        {
            var witch = await _context.Witches.FindAsync(id);

            if (witch == null)
            {
                return NotFound();
            }

            return witch;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutWitch(int id, Witches witch)
        {
            if (id != witch.Id)
            {
                return BadRequest();
            }

            _context.Entry(witch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WitchExist(id))
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

       
        [HttpPost]
        public async Task<ActionResult<Witches>> PostWitch(Witches witch)
        {
            _context.Witches.Add(witch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWitch", new { id = witch.Id }, witch);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Witches>> DeleteWitch(int id)
        {
            var witch = await _context.Witches.FindAsync(id);
            if (witch == null)
            {
                return NotFound();
            }

            _context.Witches.Remove(witch);
            await _context.SaveChangesAsync();

            return witch;
        }

        private bool WitchExist(int id)
        {
            return _context.Witches.Any(e => e.Id == id);
        }
    }
}
