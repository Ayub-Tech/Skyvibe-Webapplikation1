using FluentValidation;
using SkyVibe_Webapplikation1.DTOs;

namespace SkyVibe_Webapplikation1.Validators
{
    public class CurrentWeatherValidator : AbstractValidator<CurrentWeatherCreateDTO>
    {
        public CurrentWeatherValidator()
        {
            RuleFor(x => x.Temperature)
                .InclusiveBetween(-100, 100)
                .WithMessage("Temperaturen måste vara mellan -100 och 100 grader.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.LocationId)
                .GreaterThan(0)
                .WithMessage("LocationId är obligatoriskt.");
        }
    }
}
