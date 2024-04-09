namespace UserManagement.Application.Validation.Booking;

public sealed class AddBookingDetailsValidator : AbstractValidator<AddBookingDetailsViewModel>
{
    public AddBookingDetailsValidator()
    {
        RuleFor(booking => booking.Service)
            .NotEmpty().WithMessage("Service Name is required.")
            .Length(2, 50).WithMessage("Service Name must be between 2 and 50 characters.");

        RuleFor(booking => booking.Provider)
            .NotEmpty().WithMessage("Provider Name is required.")
            .Length(2, 50).WithMessage("Provider Name must be between 2 and 50 characters.");

        RuleFor(booking => booking.Organization)
            .NotEmpty().WithMessage("Organization Name is required.")
            .Length(2, 50).WithMessage("Organization Name must be between 2 and 50 characters.");

        RuleFor(booking => booking.Location)
            .NotEmpty().WithMessage("Location Name is required.")
            .Length(2, 50).WithMessage("Location Name must be between 2 and 50 characters.")
            .Must(location => location.Contains(','))
            .WithMessage("Please include country, state, city, and street separated by commas.");


        RuleFor(user => user.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\d{10}$").WithMessage("Phone number is not valid.")
            .Length(10).WithMessage("Phone Number must be 10 characters.");
    }
}