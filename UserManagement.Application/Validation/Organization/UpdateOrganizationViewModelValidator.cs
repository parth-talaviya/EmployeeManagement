namespace UserManagement.Application.Validation.Organization;

public sealed class UpdateOrganizationViewModelValidator : AbstractValidator<UpdateOrganizationViewModel>
{
    public UpdateOrganizationViewModelValidator()
    {
        RuleFor(organization => organization.Id)
            .NotEmpty().WithMessage("Id is required.")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");

        RuleFor(organization => organization.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");
    }
}