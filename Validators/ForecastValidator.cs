using FluentValidation;
using SkyVibe_Webapplikation1.DTOs;

namespace SkyVibe_Webapplikation1.Validators
{
    public class ForecastValidator : AbstractValidator<ForecastCreateDTO>
    {
        public ForecastValidator()
        {
            RuleFor(x => x.ForecastDate)
                .GreaterThan(DateTime.Today.AddDays(-1))
                .WithMessage("Prognosdatum måste vara idag eller senare.");

            RuleFor(x => x.MinTemperature)
                .LessThanOrEqualTo(x => x.MaxTemperature)
                .WithMessage("MinTemp får inte vara högre än MaxTemp.");

            RuleFor(x => x.Summary)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.LocationId)
                .GreaterThan(0);
        }
    }
}
