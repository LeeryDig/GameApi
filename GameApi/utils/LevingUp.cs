namespace GameApi.Utils
{
    public class LevingUp
    {
        public static int CalculateLevelUp(float projectTime, float timeTaken, int difficulty)
        {
            float timeRemaing = projectTime - timeTaken;
            return (int)Math.Round(timeRemaing) * difficulty;
        }
    }
}