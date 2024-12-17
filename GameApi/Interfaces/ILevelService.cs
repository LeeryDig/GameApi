namespace GameApi.Services
{
    public interface ILevelService
    {
        int CalculateLevelUp(float projectTime, float timeTaken, int difficulty);
    }
}