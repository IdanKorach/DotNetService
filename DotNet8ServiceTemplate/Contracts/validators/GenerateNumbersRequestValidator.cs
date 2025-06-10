using FluentValidation;

namespace Contracts.Validators;

public class GenerateNumbersRequestValidator : AbstractValidator<GenerateNumbersRequest>
{
    public GenerateNumbersRequestValidator()
    {
        RuleFor(x => x.AmountToGenerate)
            .GreaterThan(0)
            .WithMessage("Amount to generate cannot be negative")
            .LessThanOrEqualTo(1000000)
            .WithMessage("Amount to generate exceeds the limit");
            

        RuleFor(x => x.Min)
            .GreaterThanOrEqualTo(-1000000)
            .WithMessage("Minimum value is too small")
            .LessThanOrEqualTo(1000000)
            .WithMessage("Minimum value is too large");

        RuleFor(x => x.Max)
            .GreaterThanOrEqualTo(-1000000)
            .WithMessage("Maximum value is too small")
            .LessThanOrEqualTo(1000000)
            .WithMessage("Maximum value is too large")
            .GreaterThan(x => x.Min)
            .WithMessage("Maximum value must be greater than minimum value");
    }
}