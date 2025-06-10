namespace Contracts;

public class GenerateNumbersResponse
{
    public IEnumerable<int> Numbers { get; set; } = new List<int>();
    
    public int Count { get; set; }
    
    public bool Success { get; set; }
    
    public string Message { get; set; } 
}