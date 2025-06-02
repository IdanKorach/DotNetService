using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GenerateRandomNumbersController(ILogger<GenerateRandomNumbersController> logger, IGenerateNumbersService generateNumbersService) : ControllerBase
{
    [HttpGet("RandomNumbers")]
    public async Task<ActionResult> RandomNumbers(int amountToGenerate, int min, int max)
    {
        var res = await generateNumbersService.GetRandomNumbers(amountToGenerate,  min, max);
        return Ok(res);
    }
}