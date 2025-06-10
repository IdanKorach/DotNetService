using Contracts;

namespace Service;

public interface IGenerateNumbersService
{
    Task<IEnumerable<int>> GetRandomNumbers(int amountToGenerate, int min, int max);
    
    Task<GenerateNumbersResponse> GenerateRandomNumbersAsync(GenerateNumbersRequest generateRequest);
}