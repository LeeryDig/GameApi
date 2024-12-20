using Level.Models;
using MongoDB.Driver;

namespace GameApi.Services
{
    public class LevelService : ILevelService
    {
        private readonly IMongoCollection<LevelModel> _context;

        public LevelService(MongoDbContext context)
        {
            _context = context.Levels;
        }

        public async Task<LevelModel> CreateLevel(LevelDto levelDto)
        {
            var levelModel = new LevelModel
            {
                Name = levelDto.Name,
                LevelRequired = levelDto.LevelRequired,
                Image = levelDto.Image
            };
            await _context.InsertOneAsync(levelModel);

            return levelModel;
        }

        public async Task<string> DeleteLevelById(string id)
        {
            await _context.DeleteOneAsync(u => u.Id == id);
            return id;
        }

        public async Task<List<LevelModel>> GetAllLevels()
        {
            return await _context.Find(level => true).ToListAsync();
        }

        public async Task<LevelModel> GetLevelById(string id)
        {
            return await _context.Find(level => level.Id == id).FirstOrDefaultAsync();
        }

        public async Task<LevelModel> UpdateLevelById(string id, LevelDto levelDto)
        {
            var filter = Builders<LevelModel>.Filter.Eq(u => u.Id, id);

            var updatedLevel = new LevelModel
            {
                Id = id,
                Name = levelDto.Name,
                LevelRequired = levelDto.LevelRequired,
                Image = levelDto.Image
            };
            await _context.ReplaceOneAsync(filter, updatedLevel);
            return updatedLevel;
        }
    }
}