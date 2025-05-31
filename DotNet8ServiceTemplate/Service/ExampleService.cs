using Model.DB;

namespace Service;
public class ExampleService(IDbManager _dbClient) : IExampleService
{
    public async Task<IEnumerable<int>> GetRunExample()
    {
        return new List<int>();
    }

    public Task<object?> GetRandomNumbers(int amountToGenerate, int min, int max)
    {
        var random = new Random();
        var numbers = new List<int>();
    
        for (var i = 0; i < amountToGenerate; i++)
        {
            numbers.Add(random.Next(min, max));
        }
    
        return Task.FromResult<object?>(numbers);
    }
}