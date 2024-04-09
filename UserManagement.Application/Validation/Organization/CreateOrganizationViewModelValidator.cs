namespace UserManagement.Application.Validation.Organization;

public sealed class CreateOrganizationViewModelValidator : AbstractValidator<AddOrganizationViewModel>
{
    public CreateOrganizationViewModelValidator()
    {
        RuleFor(organization => organization.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");
    }
}