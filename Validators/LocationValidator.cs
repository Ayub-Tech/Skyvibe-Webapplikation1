using FluentValidation;
using SkyVibe_Webapplikation1.DTOs;

namespace SkyVibe_Webapplikation1.Validators
{
    public class LocationValidator : AbstractValidator<LocationCreateDTO>
    {
        public LocationValidator()
        {
            RuleFor(x => x.CityName)
                .NotEmpty().WithMessage("CityName är obligatoriskt")
                .MaximumLength(100);

            RuleFor(x => x.CountryCode)
                .NotEmpty().WithMessage("CountryCode är obligatoriskt")
                .Length(2).WithMessage("CountryCode måste vara exakt 2 bokstäver");
        }
    }
}
