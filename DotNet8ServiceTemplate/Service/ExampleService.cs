using Model.DB;

namespace Service;
public class ExampleService(IDbManager dbClient) : IExampleService
{
    public async Task<IEnumerable<int>> GetRunExample()
    {
        return new List<int>();
    }
}