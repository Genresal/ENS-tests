using ENS.BLL.Models;

namespace ENS.BLL.Services;
public class NamesService
{
    public List<string> ShortenNames(List<string> names)
    {
        var result = new List<string>();

        if (!names.Any()) return result;

        var users = ParseUserNames(names);

        var groupedByFirstName = users.GroupBy(x => x.FirstName?.ToLower());

        foreach (var firstNameGroup in groupedByFirstName)
        {
            if (firstNameGroup.Count() == 1)
            {
                result.Add(firstNameGroup.First().FirstName);
            }
            else
            {
                var groupedByLastInitial = firstNameGroup.GroupBy(x => x.LastName?.ToLower()[0]);

                foreach (var lastInitialGroup in groupedByLastInitial)
                {
                    if (lastInitialGroup.Count() == 1)
                    {
                        var user = lastInitialGroup.First();
                        result.Add($"{user.FirstName} {user.LastName?[0]}");
                    }
                    else
                    {
                        foreach (var user in lastInitialGroup)
                        {
                            result.Add($"{user.FirstName} {user.LastName}");
                        }
                    }
                }
            }
        }

        return result.OrderBy(x => x).ToList();
    }

    private List<User> ParseUserNames(IEnumerable<string> rawNames) => rawNames.Select(name =>
    {
        var parts = name.Split(' ');
        return new User { FirstName = parts[0], LastName = parts[1] };
    }).ToList();
}
