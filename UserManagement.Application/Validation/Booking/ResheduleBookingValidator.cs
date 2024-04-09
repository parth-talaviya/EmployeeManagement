namespace UserManagement.Application.Validation.Booking;

public sealed class ResheduleBookingValidator : AbstractValidator<ResheduleBookingViewModel>
{
    public ResheduleBookingValidator()
    {
        RuleFor(booking => booking.Id)
            .NotEmpty().WithMessage("Id is required.")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");

        RuleFor(booking => booking.Date)
            .NotEmpty().WithMessage("Date must not be empty.")
            .Must(BeValidDate).WithMessage("Invalid date.");
    }

    private bool BeValidDate(DateTime date)
    {
        return date <= DateTime.Now;
    }
}