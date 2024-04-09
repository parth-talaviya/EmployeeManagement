namespace UserManagement.Application.Validation.ServiceProvider;

public sealed class AddServiceProviderValidator : AbstractValidator<AddServiceProviderViewModel>
{
    public AddServiceProviderValidator()
    {
        RuleFor(serviceProvider => serviceProvider.ProviderId)
            .NotEmpty().WithMessage(" Provider Id is required.")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");


        RuleFor(serviceProvider => serviceProvider.ServiceId)
            .NotEmpty().WithMessage("Service Id is required.")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
    }
}