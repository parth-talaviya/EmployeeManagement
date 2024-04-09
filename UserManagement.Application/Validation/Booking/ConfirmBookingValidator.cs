namespace UserManagement.Application.Validation.Booking;

public sealed class ConfirmBookingValidator : AbstractValidator<ConfirmBookingViewModel>
{
    public ConfirmBookingValidator()
    {
        RuleFor(booking => booking.Id)
            .NotEmpty().WithMessage("Id is required.")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");

        RuleFor(booking => booking.ConfirmBooking)
            .NotEmpty().WithMessage("Not Send Empty");
    }
}