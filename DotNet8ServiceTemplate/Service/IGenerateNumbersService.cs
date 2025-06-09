using Contracts;

namespace Service;

public interface IGenerateNumbersService
{
    public Task<IEnumerable<int>> GetRandomNumbers(int amountToGenerate, int min, int max);
    
    Task<GenerateNumbersResponse> GenerateRandomNumbersAsync(GenerateNumbersRequest request);
}