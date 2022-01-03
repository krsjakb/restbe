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
    public class NotebookModelController : ControllerBase
    {
        private readonly MainDbContext _context;

        public NotebookModelController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/NotebookModel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotebookModel>>> GetNotebookModel()
        {
            return await _context.NotebookModel.ToListAsync();
        }

        // GET: api/NotebookModel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NotebookModel>> GetNotebookModel(int id)
        {
            var notebookModel = await _context.NotebookModel.FirstOrDefaultAsync(c => c.Id == id);

            if (notebookModel == null)
            {
                return NotFound();
            }

            return notebookModel;
        }

        // PUT: api/NotebookModel/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNotebookModel(int id, NotebookModel notebookModel)
        {
            if (id != notebookModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(notebookModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NotebookModelExists(id))
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

        // POST: api/NotebookModel
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<NotebookModel>> PostNotebookModel(NotebookModel notebookModel)
        {
            _context.NotebookModel.Add(notebookModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNotebookModel", new { id = notebookModel.Id }, notebookModel);
        }

        // DELETE: api/NotebookModel/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<NotebookModel>> DeleteNotebookModel(int id)
        {
            var notebookModel = await _context.NotebookModel.FindAsync(id);
            if (notebookModel == null)
            {
                return NotFound();
            }

            _context.NotebookModel.Remove(notebookModel);
            await _context.SaveChangesAsync();

            return notebookModel;
        }

        private bool NotebookModelExists(int id)
        {
            return _context.NotebookModel.Any(e => e.Id == id);
        }
    }
}
