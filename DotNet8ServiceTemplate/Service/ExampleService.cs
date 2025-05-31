using Model.DB;

namespace Service;
public class ExampleService(IDbManager _dbClient) : IExampleService
{
    public async Task<IEnumerable<int>> GetRunExample()
    {
        return new List<int>();
    }
}