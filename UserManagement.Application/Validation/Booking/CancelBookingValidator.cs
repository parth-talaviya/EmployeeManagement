namespace UserManagement.Application.Validation.Booking;

public sealed class CancelBookingValidator : AbstractValidator<CancelBookingViewModel>
{
    public CancelBookingValidator()
    {
        RuleFor(booking => booking.Id)
            .NotEmpty().WithMessage("Id is required.")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");


        RuleFor(booking => booking.CancelBooking)
            .NotEmpty().WithMessage("Not Send Empty");
    }
}