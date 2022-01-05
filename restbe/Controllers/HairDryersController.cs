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
    public class HairDryersController : ControllerBase
    {
        private readonly MainDbContext _context;

        public HairDryersController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/HairDryers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HairDryer>>> GetHairDryer()
        {
            return await _context.HairDryer.ToListAsync();
        }

        // GET: api/HairDryers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HairDryer>> GetHairDryer(int id)
        {
            var hairDryer = await _context.HairDryer.FindAsync(id);

            if (hairDryer == null)
            {
                return NotFound();
            }

            return hairDryer;
        }

        // PUT: api/HairDryers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHairDryer(int id, HairDryer hairDryer)
        {
            if (id != hairDryer.Id)
            {
                return BadRequest();
            }

            _context.Entry(hairDryer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HairDryerExists(id))
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

        // POST: api/HairDryers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HairDryer>> PostHairDryer(HairDryer hairDryer)
        {
            _context.HairDryer.Add(hairDryer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHairDryer", new { id = hairDryer.Id }, hairDryer);
        }

        // DELETE: api/HairDryers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HairDryer>> DeleteHairDryer(int id)
        {
            var hairDryer = await _context.HairDryer.FindAsync(id);
            if (hairDryer == null)
            {
                return NotFound();
            }

            _context.HairDryer.Remove(hairDryer);
            await _context.SaveChangesAsync();

            return hairDryer;
        }

        private bool HairDryerExists(int id)
        {
            return _context.HairDryer.Any(e => e.Id == id);
        }
    }
}
