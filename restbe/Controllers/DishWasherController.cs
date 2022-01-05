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
    public class DishWasherController : ControllerBase
    {
        private readonly MainDbContext _context;

        public DishWasherController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/DishWasher
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HairDryer>>> GetHairDryer()
        {
            return await _context.DishWasher.ToListAsync();
        }

        // GET: api/DishWasher/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HairDryer>> GetHairDryer(int id)
        {
            var dishWasher = await _context.DishWasher.FindAsync(id);

            if (dishWasher == null)
            {
                return NotFound();
            }

            return dishWasher;
        }

        // PUT: api/DishWasher/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDishWasher(int id, DishWasher dishWasher)
        {
            if (id != dishWasher.Id)
            {
                return BadRequest();
            }

            _context.Entry(dishWasher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishWasherExists(id))
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

        // POST: api/DishWasher
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<DishWasher>> PostDishWasher(DishWasher dishWasher)
        {
            _context.DishWasher.Add(dishWasher);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDishWasher", new { id = dishWasher.Id }, dishWasher);
        }

        // DELETE: api/DishWasher/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DishWasher>> DeleteDishWasher(int id)
        {
            var dishWasher = await _context.DishWasher.FindAsync(id);
            if (dishWasher == null)
            {
                return NotFound();
            }

            _context.DishWasher.Remove(dishWasher);
            await _context.SaveChangesAsync();

            return dishWasher;
        }

        private bool DishWasherExists(int id)
        {
            return _context.DishWasher.Any(e => e.Id == id);
        }
    }
}
