namespace UserManagement.Application.Validation.Service;

public sealed class AddServiceValidator : AbstractValidator<AddServiceViewModel>
{
    public AddServiceValidator()
    {
        RuleFor(service => service.Name)
            .NotEmpty().WithMessage(" Service Name is required.")
            .Length(2, 50).WithMessage("Service Name must be between 2 and 50 characters.");
    }
}