using Model.DB;

namespace Service;
public class GenerateRandomNumbersService(IDbManager _dbClient) : IGenerateRandomNumbersService
{
    public Task<IEnumerable<int>> GetRandomNumbers(int amountToGenerate, int min, int max)
    {
        var random = new Random();
        var numbers = new List<int>();
    
        for (var i = 0; i < amountToGenerate; i++)
        {
            numbers.Add(random.Next(min, max));
        }
    
        return Task.FromResult<IEnumerable<int>>(numbers);
    }
}