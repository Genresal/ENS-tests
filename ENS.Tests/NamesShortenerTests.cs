using ENS.BLL.Services;

namespace ENS.Tests;

public class NamesShortenerTests
{
    private readonly NamesService _namesService = new();

    [Fact]
    public void ShortenNames_UniqeNames_ReturnsFirstNames()
    {
        var names = new List<string> { "John Smith", "Alice Brown", "Bob Smith" };

        var result = _namesService.ShortenNames(names);

        Assert.Equal(["Alice", "Bob", "John"], result);
    }

    [Fact]
    public void ShortenNames_SameFirstNameDifferentLastNames_ReturnsFirstNameWithLastInitial()
    {
        var names = new List<string> { "John Smith", "John Doe", "John Baker" };

        var result = _namesService.ShortenNames(names);

        Assert.Equal(["John B", "John D", "John S"], result);
    }

    [Fact]
    public void ShortenNames_SameFirstNameAndLastInitial_ReturnsFullNames()
    {
        var names = new List<string> { "John Smith", "John Stevens", "John Stuart" };

        var result = _namesService.ShortenNames(names);

        Assert.Equal(["John Smith", "John Stevens", "John Stuart"], result);
    }

    [Fact]
    public void ShortenNames_DifferentCases_ReturnsNormalizedNames()
    {
        var names = new List<string> { "john smith", "John Doe", "JOHN baker", "Alice Brown", "Alice Brown", "Steven Trump" };

        var result = _namesService.ShortenNames(names);

        Assert.Equal(["Alice Brown", "Alice Brown", "JOHN b", "John D", "john s", "Steven"], result);
    }

    [Fact]
    public void ShortenNames_EmptyList_ReturnsEmptyList()
    {
        var names = new List<string>();

        var result = _namesService.ShortenNames(names);

        Assert.Equal([], result);
    }
}