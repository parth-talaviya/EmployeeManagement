namespace UserManagement.Application.Validation.Country;

public sealed class EditCountryValidator : AbstractValidator<EditCountryDetailsViewModel>
{
    public EditCountryValidator()
    {
        RuleFor(country => country.Id)
            .NotEmpty().WithMessage("Id is required.")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");

        RuleFor(country => country.Name)
            .NotEmpty().WithMessage("Country Name is required.")
            .Length(2, 50).WithMessage("Country Name must be between 2 and 50 characters.");

        RuleFor(country => country.RegionCode)
            .NotEmpty().WithMessage("Region Code is required.")
            .Length(2, 10).WithMessage("Region Code must be between 2 and 10 characters.");
    }
}