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
    public class IphoneController : ControllerBase
    {
        private readonly MainDbContext _context;

        public IphoneController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/Iphone
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Iphone>>> GetIphone()
        {
            return await _context.Iphone.ToListAsync();
        }

        // GET: api/Iphone/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Iphone>> GetIphone(int id)
        {
            var iphone = await _context.Iphone.FindAsync(id);

            if (iphone == null)
            {
                return NotFound();
            }

            return iphone;
        }

        // PUT: api/Iphone/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIphone(int id, Iphone iphone)
        {
            if (id != iphone.ID)
            {
                return BadRequest();
            }

            _context.Entry(iphone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IphoneExists(id))
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

        // POST: api/Iphone
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Iphone>> PostIphone(Iphone iphone)
        {
            _context.Iphone.Add(iphone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIphone", new { id = iphone.ID }, iphone);
        }

        // DELETE: api/Iphone/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Iphone>> DeleteIphone(int id)
        {
            var iphone = await _context.Iphone.FindAsync(id);
            if (iphone == null)
            {
                return NotFound();
            }

            _context.Iphone.Remove(iphone);
            await _context.SaveChangesAsync();

            return iphone;
        }

        private bool IphoneExists(int id)
        {
            return _context.Iphone.Any(e => e.ID == id);
        }
    }
}