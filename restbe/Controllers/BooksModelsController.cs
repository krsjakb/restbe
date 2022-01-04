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
    public class BooksModelsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public BooksModelsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/BooksModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BooksModel>>> GetBooksModel()
        {
            return await _context.BooksModel.ToListAsync();
        }

        // GET: api/BooksModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BooksModel>> GetBooksModel(int id)
        {
            var booksModel = await _context.BooksModel.FindAsync(id);

            if (booksModel == null)
            {
                return NotFound();
            }

            return booksModel;
        }

        // PUT: api/BooksModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooksModel(int id, BooksModel booksModel)
        {
            if (id != booksModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(booksModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BooksModelExists(id))
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

        // POST: api/BooksModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BooksModel>> PostBooksModel(BooksModel booksModel)
        {
            _context.BooksModel.Add(booksModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBooksModel", new { id = booksModel.Id }, booksModel);
        }

        // DELETE: api/BooksModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BooksModel>> DeleteBooksModel(int id)
        {
            var booksModel = await _context.BooksModel.FindAsync(id);
            if (booksModel == null)
            {
                return NotFound();
            }

            _context.BooksModel.Remove(booksModel);
            await _context.SaveChangesAsync();

            return booksModel;
        }

        private bool BooksModelExists(int id)
        {
            return _context.BooksModel.Any(e => e.Id == id);
        }
    }
}
