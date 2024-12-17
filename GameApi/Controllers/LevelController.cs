using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Level.Models;

namespace GameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly LevelContext _context;

        public LevelController(LevelContext context)
        {
            _context = context;
        }

        // GET: api/Level
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LevelModel>>> GetLevelModels()
        {
            if (_context.LevelModels == null)
            {
                return NotFound();
            }
            return await _context.LevelModels.ToListAsync();
        }

        // GET: api/Level/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LevelModel>> GetLevelModel(long id)
        {
            if (_context.LevelModels == null)
            {
                return NotFound();
            }
            var levelModel = await _context.LevelModels.FindAsync(id);

            if (levelModel == null)
            {
                return NotFound();
            }

            return levelModel;
        }

        // PUT: api/Level/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLevelModel(long id, LevelModel levelModel)
        {
            if (id != levelModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(levelModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LevelModelExists(id))
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

        // POST: api/Level
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LevelModel>> PostLevelModel(LevelModel levelModel)
        {
            if (_context.LevelModels == null)
            {
                return Problem("Entity set 'LevelContext.LevelModels'  is null.");
            }
            _context.LevelModels.Add(levelModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLevelModel", new { id = levelModel.Id }, levelModel);
        }

        // DELETE: api/Level/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLevelModel(long id)
        {
            if (_context.LevelModels == null)
            {
                return NotFound();
            }
            var levelModel = await _context.LevelModels.FindAsync(id);
            if (levelModel == null)
            {
                return NotFound();
            }

            _context.LevelModels.Remove(levelModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LevelModelExists(long id)
        {
            return (_context.LevelModels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
