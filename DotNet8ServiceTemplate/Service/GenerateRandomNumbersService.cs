using Microsoft.Extensions.Logging;
using Model.DB;
using Service.Configuration;

namespace Service;
public class GenerateRandomNumbersService(IDbManager dbClient, FeatureFlags featureFlags, ILogger<GenerateRandomNumbersService> logger) : IGenerateNumbersService
{
    public Task<IEnumerable<int>> GetRandomNumbers(int amountToGenerate, int min, int max)
    {
        if (featureFlags.EnableNewLogging)
        {
            logger.LogInformation("Generating {Amount} random numbers between {Min} and {Max} with new logging enabled", 
                amountToGenerate, min, max);
        }
        
        var random = new Random();
        var numbers = new List<int>();
    
        for (var i = 0; i < amountToGenerate; i++)
        {
            numbers.Add(random.Next(min, max));
        }

        if (!featureFlags.EnableNewLogging) return Task.FromResult<IEnumerable<int>>(numbers);
        logger.LogInformation("Successfully generated {Count} random numbers", numbers.Count);
        logger.LogDebug("Generated numbers: {Numbers}", string.Join(", ", numbers));

        return Task.FromResult<IEnumerable<int>>(numbers);
    }
}