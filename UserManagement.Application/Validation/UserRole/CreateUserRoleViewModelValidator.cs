namespace UserManagement.Application.Validation.UserRole;

public sealed class CreateUserRoleViewModelValidator : AbstractValidator<AddUserRoleViewModel>
{
    public CreateUserRoleViewModelValidator()
    {
        RuleFor(userRole => userRole.UserId)
            .NotEmpty().WithMessage("UserId is required.")
            .GreaterThan(0).WithMessage("UserId must be greater than 0.");

        RuleFor(userRole => userRole.RoleId)
            .NotEmpty().WithMessage("RoleId is required.")
            .GreaterThan(0).WithMessage("RoleId must be greater than 0.");
    }
}