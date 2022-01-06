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
    public class ZoosController : ControllerBase
    {
        private readonly MainDbContext _context;

        public ZoosController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/Zoos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zoo>>> GetZoo()
        {
            return await _context.Zoo.ToListAsync();
        }

        // GET: api/Zoos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Zoo>> GetZoo(int id)
        {
            var zoo = await _context.Zoo.FindAsync(id);

            if (zoo == null)
            {
                return NotFound();
            }

            return zoo;
        }

        // PUT: api/Zoos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZoo(int id, Zoo zoo)
        {
            if (id != zoo.Id)
            {
                return BadRequest();
            }

            _context.Entry(zoo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZooExists(id))
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

        // POST: api/Zoos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Zoo>> PostZoo(Zoo zoo)
        {
            _context.Zoo.Add(zoo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZoo", new { id = zoo.Id }, zoo);
        }

        // DELETE: api/Zoos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Zoo>> DeleteZoo(int id)
        {
            var zoo = await _context.Zoo.FindAsync(id);
            if (zoo == null)
            {
                return NotFound();
            }

            _context.Zoo.Remove(zoo);
            await _context.SaveChangesAsync();

            return zoo;
        }

        private bool ZooExists(int id)
        {
            return _context.Zoo.Any(e => e.Id == id);
        }
    }
}
