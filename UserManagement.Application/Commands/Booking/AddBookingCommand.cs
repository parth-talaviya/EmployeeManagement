namespace UserManagement.Application.Commands.Booking;

public sealed record class AddBookingCommand(AddBookingDetailsViewModel AddBookingModel)
    : IRequest<AddBookingDetailsViewModel>;