using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExampleController(ILogger<ExampleController> _logger, IExampleService _exampleService) : ControllerBase
{
    [HttpGet("RunExample")]
    public async Task<ActionResult> RunExample()
    {
        var res = await _exampleService.GetRunExample();
        return Ok(res);
    }
    
    [HttpGet("RandomNumbers")]
    public async Task<ActionResult> RandomNumbers(int amountToGenerate, int min, int max)
    {
        var res = await _exampleService.GetRandomNumbers(amountToGenerate,  min, max);
        return Ok(res);
    }
}