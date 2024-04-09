namespace UserManagement.Application.Commands.Booking;

public sealed record CancelBookingCommand(CancelBookingViewModel CancelDetailsViewModel)
    : IRequest<CancelBookingViewModel>;