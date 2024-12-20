using Level.Models;

namespace GameApi.Services
{
    public interface ILevelService
    {
        Task<List<LevelModel>> GetAllLevels();
        Task<LevelModel> GetLevelById(string id);
        Task<LevelModel> CreateLevel(LevelDto levelDto);
        Task<LevelModel> UpdateLevelById(string id, LevelDto levelDto);
        Task<string> DeleteLevelById(string id);
    }
}