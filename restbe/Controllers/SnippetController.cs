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
    public class SnippetController : ControllerBase
    {
        private readonly MainDbContext _context;

        public SnippetController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/Snippet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Snippet>>> GetSnippet()
        {
            return await _context.Snippet
                //.Include(c => c.CodeBlock)
                .ToListAsync();
        }

        // GET: api/Snippet/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Snippet>> GetSnippet(int id)
        {
            var snippet = await _context.Snippet
                //.Include(c => c.CodeBlock)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (snippet == null)
            {
                return NotFound();
            }

            return snippet;
        }

        // PUT: api/Snippet/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSnippet(int id, Snippet snippet)
        {
            if (id != snippet.Id)
            {
                return BadRequest();
            }

            _context.Entry(snippet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SnippetExists(id))
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

        // POST: api/Snippet
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Snippet>> PostSnippet(Snippet snippet)
        {
            _context.Snippet.Add(snippet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSnippet", new { id = snippet.Id }, snippet);
        }

        // DELETE: api/Snippet/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<Snippet>> DeleteSnippet(int id)
        {
            var snippet = await _context.Snippet.FindAsync(id);
            if (snippet == null)
            {
                return NotFound();
            }

            _context.Snippet.Remove(snippet);
            await _context.SaveChangesAsync();

            return snippet;
        }

        private bool SnippetExists(int id)
        {
            return _context.Snippet.Any(e => e.Id == id);
        }
    }
}
