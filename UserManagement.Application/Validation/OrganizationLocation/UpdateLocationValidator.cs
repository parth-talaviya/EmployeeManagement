namespace UserManagement.Application.Validation.OrganizationLocation;

public sealed class UpdateLocationValidator : AbstractValidator<UpdateLocationDetailsViewModel>
{
    public UpdateLocationValidator()
    {

        RuleFor(location => location.Id)
           .NotEmpty().WithMessage("Id is required.")
           .GreaterThan(0).WithMessage("Id must be greater than 0.");

        RuleFor(location => location.Country)
            .NotEmpty().WithMessage(" Country Name is required.")
            .Length(2, 50).WithMessage("Country Name must be between 2 and 50 characters.");

        RuleFor(location => location.State)
            .NotEmpty().WithMessage("State Name is required.")
            .Length(2, 50).WithMessage("State Name must be between 2 and 50 characters.");

        RuleFor(location => location.City)
            .NotEmpty().WithMessage("City Name is required.")
            .Length(2, 50).WithMessage("City Name must be between 2 and 50 characters.");

        RuleFor(location => location.Street)
            .NotEmpty().WithMessage("Street is required.")
            .Length(2, 50).WithMessage("Street Name must be between 2 and 50 characters.");
    }
}