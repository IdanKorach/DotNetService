namespace Service;

public interface IExampleService
{
    public Task<IEnumerable<int>> GetRunExample();
    Task<object?> GetRandomNumbers(int amountToGenerate, int min, int max);
}
