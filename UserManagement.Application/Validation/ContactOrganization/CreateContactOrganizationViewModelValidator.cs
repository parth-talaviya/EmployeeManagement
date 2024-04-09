namespace UserManagement.Application.Validation.ContactOrganization;

public sealed class CreateContactOrganizationViewModelValidator : AbstractValidator<AddContactOrganizationViewModel>
{
    public CreateContactOrganizationViewModelValidator()
    {
        RuleFor(contactOrganization => contactOrganization.ContactId)
            .NotEmpty().WithMessage("ContactId is required.")
            .GreaterThan(0).WithMessage("ContactId must be greater than 0.");

        RuleFor(contactOrganization => contactOrganization.OrganizationId)
            .NotEmpty().WithMessage("OrganizationId is required.")
            .GreaterThan(0).WithMessage("OrganizationId must be greater than 0.");
    }
}