namespace Service;

public interface IExampleService
{
    public Task<IEnumerable<int>> RunExample();
}
