namespace UserManagement.Application.Validation;

public sealed class UserViewModelValidator : AbstractValidator<CreateUserViewModel>
{
    public UserViewModelValidator()
    {
        RuleFor(user => user.Name)
            .NotEmpty().WithMessage("Name is required.")
            .Length(2, 50).WithMessage("Name must be between 2 and 50 characters.");

        RuleFor(user => user.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Length(6, 50).WithMessage("Password must be between 6 and 50 characters.");

        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email is not valid.");

        RuleFor(user => user.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\d{10}$").WithMessage("Phone number is not valid.");

        RuleFor(user => user.City)
            .NotEmpty().WithMessage("City is required.")
            .Length(2, 50).WithMessage("City must be between 2 and 50 characters.");

        RuleFor(user => user.ImageURL)
            .NotEmpty().WithMessage("Image URL is required.");
    }
}