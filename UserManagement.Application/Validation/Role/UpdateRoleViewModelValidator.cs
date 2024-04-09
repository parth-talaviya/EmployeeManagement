namespace UserManagement.Application.Validation.Role;

public sealed class UpdateRoleViewModelValidator : AbstractValidator<UpdateRoleViewModel>
{
    public UpdateRoleViewModelValidator()
    {
        RuleFor(role => role.Id)
            .NotEmpty().WithMessage("Id is required.")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");

        RuleFor(role => role.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");
    }
}