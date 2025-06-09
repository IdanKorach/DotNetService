using Microsoft.Extensions.Logging;
using Model.DB;
using Service.Configuration;
using Contracts;

namespace Service;

public class GenerateRandomNumbersService(
    IDbManager dbClient, 
    FeatureFlags featureFlags, 
    ILogger<GenerateRandomNumbersService> logger) : IGenerateNumbersService
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

        if (featureFlags.EnableNewLogging)
        {
            logger.LogInformation("Successfully generated {Count} random numbers", numbers.Count);
            logger.LogDebug("Generated numbers: {Numbers}", string.Join(", ", numbers));
        }
        
        return Task.FromResult<IEnumerable<int>>(numbers);
    }

    public async Task<GenerateNumbersResponse> GenerateRandomNumbersAsync(GenerateNumbersRequest request)
    {
        try
        {
            if (featureFlags.EnableNewLogging)
            {
                logger.LogInformation("Processing GenerateNumbersRequest with Amount: {Amount}, Min: {Min}, Max: {Max}", 
                    request.AmountToGenerate, request.Min, request.Max);
            }

            var numbers = await GetRandomNumbers(request.AmountToGenerate, request.Min, request.Max);
            var numbersList = numbers.ToList();

            if (featureFlags.EnableNewLogging)
            {
                logger.LogInformation("Successfully processed request, generated {Count} numbers", numbersList.Count);
            }

            return new GenerateNumbersResponse
            {
                Numbers = numbersList,
                Count = numbersList.Count,
                Success = true,
                Message = "Numbers generated successfully"
            };
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error generating random numbers");
            
            return new GenerateNumbersResponse
            {
                Numbers = new List<int>(),
                Count = 0,
                Success = false,
                Message = $"An error occurred: {ex.Message}"
            };
        }
    }
}