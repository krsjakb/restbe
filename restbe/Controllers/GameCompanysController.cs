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
    public class GameCompanysController : ControllerBase
    {
        private readonly MainDbContext _context;

        public GameCompanysController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/GameCompanys
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameCompanys>>> GetGameCompanys()
        {
            return await _context.GameCompanys
                .Include(c => c.GameModels)
                .ToListAsync();
        }

        // GET: api/GameCompanys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameCompanys>> GetGameCompanys(int id)
        {
            var gameCompanys = await _context.GameCompanys
                .Include(c => c.GameModels)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (gameCompanys == null)
            {
                return NotFound();
            }

            return gameCompanys;
        }

        // PUT: api/GameCompanys/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGameCompanys(int id, GameCompanys gameCompanys)
        {
            if (id != gameCompanys.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameCompanys).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameCompanysExists(id))
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

        // POST: api/GameCompanys
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GameCompanys>> PostCarBrands(GameCompanys gameCompanys)
        {
            _context.GameCompanys.Add(gameCompanys);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameCompanys", new { id = gameCompanys.Id }, gameCompanys);
        }

        // DELETE: api/GameCompanys/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GameCompanys>> DeleteGameCompanys(int id)
        {
            var gameCompanys = await _context.GameCompanys.FindAsync(id);
            if (gameCompanys == null)
            {
                return NotFound();
            }

            _context.GameCompanys.Remove(gameCompanys);
            await _context.SaveChangesAsync();

            return gameCompanys;
        }

        private bool GameCompanysExists(int id)
        {
            return _context.GameCompanys.Any(e => e.Id == id);
        }
    }
}
