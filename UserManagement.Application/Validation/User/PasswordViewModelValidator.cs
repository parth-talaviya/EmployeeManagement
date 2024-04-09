namespace UserManagement.Application.Validation;

public sealed class UserPasswordUpdateViewModelValidator : AbstractValidator<UserPasswordUpdateViewModel>
{
    public UserPasswordUpdateViewModelValidator()
    {
        RuleFor(user => user.Id)
            .NotEmpty().WithMessage("Id is required.")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");

        RuleFor(user => user.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Length(6, 50).WithMessage("Password must be between 6 and 50 characters.");
    }
}