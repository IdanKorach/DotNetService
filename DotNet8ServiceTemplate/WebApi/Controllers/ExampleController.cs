using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ExampleController(ILogger<ExampleController> _logger, IExampleService exampleService) : ControllerBase
{
    [HttpGet("RunExample")]
    public async Task<ActionResult> RunExample()
    {
        var res = await exampleService.GetRunExample();
        return Ok(res);
    }
}