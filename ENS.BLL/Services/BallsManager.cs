namespace ENS.BLL.Services;
public static class BallsManager
{
    public static List<int> GetBalls(List<int> balls, int capacity)
    {
        var totalBalls = balls.Sum();

        if (capacity >= totalBalls)
            return new List<int>(balls);

        var proportions = balls.Select(x => (double)x / totalBalls).ToList();

        var stolenBalls = proportions.Select(x => (int)Math.Floor(x * capacity)).ToList();

        var currentTotal = stolenBalls.Sum();
        var remainingCapacity = capacity - currentTotal;

        if (remainingCapacity > 0)
        {
            var orderedIndices = Enumerable.Range(0, balls.Count)
                .OrderByDescending(i => proportions[i])
                .ToList();

            for (int i = 0; i < remainingCapacity; i++)
            {
                stolenBalls[orderedIndices[i % balls.Count]]++;
            }
        }

        return stolenBalls;
    }
}
