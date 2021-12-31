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
    public class GameModelsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public GameModelsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/GameModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameModel>>> GetGameModel()
        {
            return await _context.GameModel
                .Include(c => c.GameCompany)
                .ToListAsync();
        }

        // GET: api/GameModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GameModel>> GetGameModel(int id)
        {
            var gameModel = await _context.GameModel
                .Include(c => c.GameCompany)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (gameModel == null)
            {
                return NotFound();
            }

            return gameModel;
        }

        // PUT: api/GModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarModel(int id, GameModel gameModel)
        {
            if (id != gameModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(gameModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameModelExists(id))
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

        // POST: api/GModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GameModel>> PostGameModel(GameModel gameModel)
        {
            _context.GameModel.Add(gameModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGameModel", new { id = gameModel.Id }, gameModel);
        }

        // DELETE: api/GModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GameModel>> DeleteGameModel(int id)
        {
            var gameModel = await _context.GameModel.FindAsync(id);
            if (gameModel == null)
            {
                return NotFound();
            }

            _context.GameModel.Remove(gameModel);
            await _context.SaveChangesAsync();

            return gameModel;
        }

        private bool GameModelExists(int id)
        {
            return _context.GameModel.Any(e => e.Id == id);
        }
    }
}
