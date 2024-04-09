namespace UserManagement.Application.Validation.Service;

public sealed class UpdateServiceValidator : AbstractValidator<EditServiceViewModel>
{
    public UpdateServiceValidator()
    {
        RuleFor(service => service.Id)
            .NotEmpty().WithMessage("Id is required.")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");

        RuleFor(service => service.Name)
            .NotEmpty().WithMessage(" Service Name is required.")
            .Length(2, 50).WithMessage("Service Name must be between 2 and 50 characters.");
    }
}