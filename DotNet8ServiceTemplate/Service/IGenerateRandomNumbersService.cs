namespace Service;

public interface IGenerateRandomNumbersService
{
    public Task<IEnumerable<int>> GetRandomNumbers(int amountToGenerate, int min, int max);
}