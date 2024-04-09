namespace UserManagement.Application.Validation.Providers;

public sealed class AddProviderValidator : AbstractValidator<AddProvidersViewModel>
{
    public AddProviderValidator()
    {
        RuleFor(provider => provider.ProviderName)
            .NotEmpty().WithMessage(" Provider Name is required.")
            .Length(2, 50).WithMessage("Provider Name must be between 2 and 50 characters.");
    }
}