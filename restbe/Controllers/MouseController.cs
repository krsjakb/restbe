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
    public class MousesController : ControllerBase
    {
        private readonly MainDbContext _context;

        public MousesController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/Mouses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mouse>>> GetMouse()
        {
            return await _context.Mouse.ToListAsync();
        }

        // GET: api/Mouses/5
        [HttpGet("{Id}")]
        public async Task<ActionResult<Mouse>> GetMouse(int Id)
        {
            var Mouse = await _context.Mouse.FindAsync(Id);

            if (Mouse == null)
            {
                return NotFound();
            }

            return Mouse;
        }

        // PUT: api/Mouses/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkId=2123754.
        [HttpPut("{Id}")]
        public async Task<IActionResult> PutMouse(int Id, Mouse Mouse)
        {
            if (Id != Mouse.Id)
            {
                return BadRequest();
            }

            _context.Entry(Mouse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MouseExists(Id))
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

        // POST: api/Mouses
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkId=2123754.
        [HttpPost]
        public async Task<ActionResult<Mouse>> PostMouse(Mouse Mouse)
        {
            _context.Mouse.Add(Mouse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMouse", new { Id = Mouse.Id }, Mouse);
        }

        // DELETE: api/Mouses/5
        [HttpDelete("{Id}")]
        public async Task<ActionResult<Mouse>> DeleteMouse(int Id)
        {
            var Mouse = await _context.Mouse.FindAsync(Id);
            if (Mouse == null)
            {
                return NotFound();
            }

            _context.Mouse.Remove(Mouse);
            await _context.SaveChangesAsync();

            return Mouse;
        }

        private bool MouseExists(int Id)
        {
            return _context.Mouse.Any(e => e.Id == Id);
        }
    }
}