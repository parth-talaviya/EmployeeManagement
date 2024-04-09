namespace UserManagement.Application.Commands.Booking;

public sealed record ConfirmBookingCommand(ConfirmBookingViewModel ConfirmDetailsViewModel)
    : IRequest<ConfirmBookingViewModel>;