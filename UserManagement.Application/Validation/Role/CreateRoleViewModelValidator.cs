namespace UserManagement.Application.Validation.Role;

public sealed class CreateRoleViewModelValidator : AbstractValidator<AddRoleViewModel>
{
    public CreateRoleViewModelValidator()
    {
        RuleFor(role => role.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");
    }
}