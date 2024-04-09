namespace UserManagement.Application.Handlers.Booking;

public sealed class ConfrimBookingHandler : IRequestHandler<ConfirmBookingCommand, ConfirmBookingViewModel?>
{
    private readonly IBookingService _bookingDetailService;

    public ConfrimBookingHandler(IBookingService bookingDetailService)
    {
        _bookingDetailService = bookingDetailService;
    }

    public Task<ConfirmBookingViewModel?> Handle(ConfirmBookingCommand editConfirmBookingCommand,
        CancellationToken cancellationToken)
    {
        return _bookingDetailService.ConfirmBookingAsync(editConfirmBookingCommand.ConfirmDetailsViewModel,
            cancellationToken);
    }
}