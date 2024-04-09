namespace UserManagement.Application.Validation.Providers;

public sealed class UpdateProviderValidator : AbstractValidator<EditProvidersViewModel>
{
    public UpdateProviderValidator()
    {
        RuleFor(provider => provider.Id)
            .NotEmpty().WithMessage("Id is required.")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");

        RuleFor(provider => provider.ProviderName)
            .NotEmpty().WithMessage(" Provider Name is required.")
            .Length(2, 50).WithMessage("Provider Name must be between 2 and 50 characters.");
    }
}