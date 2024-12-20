using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Level.Models;
using GameApi.Services;
using MongoDB.Driver;

namespace GameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly IMongoCollection<LevelModel> _context;
        private readonly ILevelService _services;

        public LevelController(MongoDbContext context, ILevelService services)
        {
            _context = context.Levels;
            _services = services;

        }

        // GET: api/Level
        [HttpGet]
        public async Task<ActionResult<List<LevelModel>>> GetAllLevels()
        {
            try
            {
                var users = await _services.GetAllLevels();
                return Ok(users);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET: api/Level/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LevelModel>> GetLevelById(string id)
        {
            try
            {
                var users = await _services.GetLevelById(id);
                return Ok(users);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT: api/Level/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLevelById(string id, LevelDto levelModel)
        {
            try
            {
                var result = await _services.UpdateLevelById(id, levelModel);
                return Ok(result);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST: api/Level
        [HttpPost]
        public async Task<ActionResult<LevelModel>> CreateLevel(LevelDto level)
        {
            try
            {
                var createdLevel = await _services.CreateLevel(level);
                return Ok(createdLevel);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE: api/Level/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLevelById(string id)
        {
            try
            {
                var level = await _services.DeleteLevelById(id);
                return Ok(level);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
