using Contracts;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GenerateRandomNumbersController(
    ILogger<GenerateRandomNumbersController> logger,
    IGenerateNumbersService generateNumbersService) : ControllerBase
{
    [HttpGet("RandomNumbers")]
    public async Task<ActionResult> RandomNumbers(int amountToGenerate, int min, int max)
    {
        var res = await generateNumbersService.GetRandomNumbers(amountToGenerate, min, max);
        return Ok(res);
    }

    [HttpPost("generate")]
    public async Task<IActionResult> GenerateNumbers(
        [FromBody] GenerateNumbersRequest request,
        IValidator<GenerateNumbersRequest> validator) 
    {
        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            foreach (var error in validationResult.Errors)
            {
                logger.LogWarning("Validation failed for field '{Field}': {Error}",
                    error.PropertyName, error.ErrorMessage);
            }

            logger.LogWarning("Request rejected due to {ErrorCount} validation error(s)",
                validationResult.Errors.Count);

            return BadRequest(validationResult.Errors.Select(e => new {
                Field = e.PropertyName,
                Message = e.ErrorMessage
            }));
        }

        var response = await generateNumbersService.GenerateRandomNumbersAsync(request);
        return Ok(response);
    }
}