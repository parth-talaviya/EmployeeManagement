namespace UserManagement.Application.Handlers.Booking;

public sealed class AddBookingHandler : IRequestHandler<AddBookingCommand, AddBookingDetailsViewModel?>
{
    private readonly IBookingService _bookingDetailService;

    public AddBookingHandler(IBookingService bookingDetailService)
    {
        _bookingDetailService = bookingDetailService;
    }

    public Task<AddBookingDetailsViewModel?> Handle(AddBookingCommand addBookingCommand,
        CancellationToken cancellationToken)
    {
        return _bookingDetailService.AddBookingAsync(addBookingCommand.AddBookingModel, cancellationToken);
    }
}