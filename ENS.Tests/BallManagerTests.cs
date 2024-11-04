using ENS.BLL.Services;

namespace ENS.Tests;
public class BallManagerTests
{
    [Fact]
    public void GetBalls_Proportional()
    {
        var balls = new List<int> { 100, 300, 200 };
        var capacity = 120;

        var result = BallsManager.GetBalls(balls, capacity);

        Assert.Equal([20, 60, 40], result);
    }

    [Fact]
    public void GetBalls_Equal()
    {
        var balls = new List<int> { 50, 50 };
        var capacity = 10;

        var result = BallsManager.GetBalls(balls, capacity);

        Assert.Equal([5, 5], result);
    }

    [Fact]
    public void GetBalls_ZeroCapacity_ReturnsZeros()
    {
        var balls = new List<int> { 100, 200, 300 };
        var capacity = 0;

        var result = BallsManager.GetBalls(balls, capacity);

        Assert.Equal([0, 0, 0], result);
    }

    [Fact]
    public void GetBalls_Less_Than_TotalBalls()
    {
        var balls = new List<int> { 10, 30, 60 };
        var capacity = 11;

        var result = BallsManager.GetBalls(balls, capacity);

        Assert.Equal([1, 3, 7], result);
    }

    [Fact]
    public void GetBalls_CapacityGreater_TotalBalls()
    {
        var balls = new List<int> { 100, 200, 300 };
        var capacity = 700;

        var result = BallsManager.GetBalls(balls, capacity);

        Assert.Equal([100, 200, 300], result);
    }

    [Fact]
    public void GetBalls_Single_Color()
    {
        var balls = new List<int> { 100 };
        var capacity = 50;

        var result = BallsManager.GetBalls(balls, capacity);

        Assert.Equal([50], result);
    }

    [Fact]
    public void GetBalls_Empty_ReturnsEmptyList()
    {
        var balls = new List<int>();
        var capacity = 50;

        var result = BallsManager.GetBalls(balls, capacity);

        Assert.Equal([], result);
    }

    [Fact]
    public void GetBalls_NonProportionalCapacity()
    {
        var balls = new List<int> { 7, 13, 24 };
        var capacity = 17;

        var result = BallsManager.GetBalls(balls, capacity);

        Assert.Equal([2, 5, 10], result);
    }
}
