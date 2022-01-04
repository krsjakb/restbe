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
    public class CharacterModelsController : ControllerBase
    {
        private readonly MainDbContext _context;

        public CharacterModelsController(MainDbContext context)
        {
            _context = context;
        }

        // GET: api/CharacterModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterModel>>> GetCharacterModel()
        {
            return await _context.CharacterModel.ToListAsync();
        }

        // GET: api/CharacterModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterModel>> GetCharacterModel(int id)
        {
            var characterModel = await _context.CharacterModel.FindAsync(id);

            if (characterModel == null)
            {
                return NotFound();
            }

            return characterModel;
        }

        // PUT: api/CharacterModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacterModel(int id, CharacterModel characterModel)
        {
            if (id != characterModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(characterModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterModelExists(id))
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

        // POST: api/CharacterModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CharacterModel>> PostCharacterModel(CharacterModel characterModel)
        {
            _context.CharacterModel.Add(characterModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharacterModel", new { id = characterModel.Id }, characterModel);
        }

        // DELETE: api/CharacterModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CharacterModel>> DeleteCharacterModel(int id)
        {
            var characterModel = await _context.CharacterModel.FindAsync(id);
            if (characterModel == null)
            {
                return NotFound();
            }

            _context.CharacterModel.Remove(characterModel);
            await _context.SaveChangesAsync();

            return characterModel;
        }

        private bool CharacterModelExists(int id)
        {
            return _context.CharacterModel.Any(e => e.Id == id);
        }
    }
}
