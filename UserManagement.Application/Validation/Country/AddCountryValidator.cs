namespace UserManagement.Application.Validation.Country;

public sealed class AddCountryValidator : AbstractValidator<AddCountryDetailsViewModel>
{
    public AddCountryValidator()
    {
        RuleFor(country => country.Name)
            .NotEmpty().WithMessage("Country Name is required.")
            .Length(2, 50).WithMessage("Country Name must be between 2 and 50 characters.");

        RuleFor(country => country.RegionCode)
            .NotEmpty().WithMessage("Region Code is required.")
            .Length(2, 10).WithMessage("Region Code must be between 2 and 10 characters.");
    }
}