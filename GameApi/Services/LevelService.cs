using GameApi.Services;

namespace GameApi.Services
{
    public class LevelService : ILevelService
    {
        public int CalculateLevelUp(float projectTime, float timeTaken, int difficulty)
        {
            float timeRemaing = projectTime - timeTaken;
            return (int)Math.Round(timeRemaing) * difficulty;
        }
    }
}