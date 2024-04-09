namespace UserManagement.Application.Validation.ContactDetail;

public sealed class UpdateContactViewModelValidator : AbstractValidator<UpdateContactViewModel>
{
    public UpdateContactViewModelValidator()
    {
        RuleFor(contact => contact.Id)
           .NotEmpty().WithMessage("Id is required.")
           .GreaterThan(0).WithMessage("Id must be greater than 0.");

        RuleFor(contact => contact.FirstName)
            .NotEmpty().WithMessage(" First Name is required.")
            .Length(2, 50).WithMessage("First Name must be between 2 and 50 characters.");

        //RuleFor(contact => contact.MiddleName)
        //    .NotEmpty().WithMessage("Middle Name is required.")
        //    .Length(2, 50).WithMessage("Middle Name must be between 2 and 50 characters.");

        RuleFor(contact => contact.LastName)
            .NotEmpty().WithMessage("Last Name is required.")
            .Length(2, 50).WithMessage("Last Name must be between 2 and 50 characters.");

        RuleFor(user => user.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email is not valid.");

        RuleFor(user => user.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\d{10}$").WithMessage("Phone number is not valid.")
            .Length(10).WithMessage("Phone Number must be 10 characters.");
    }
}