namespace UserManagement.Application.Commands.Booking;

public sealed record ResheduleBookingCommand(ResheduleBookingViewModel ResheduleDetailsViewModel)
    : IRequest<ResheduleBookingViewModel>;