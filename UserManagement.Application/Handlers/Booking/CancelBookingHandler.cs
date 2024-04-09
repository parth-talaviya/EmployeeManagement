namespace UserManagement.Application.Handlers.Booking;

public sealed class CancelBookingHandler : IRequestHandler<CancelBookingCommand, CancelBookingViewModel?>
{
    private readonly IBookingService _bookingDetailService;

    public CancelBookingHandler(IBookingService bookingDetailService)
    {
        _bookingDetailService = bookingDetailService;
    }

    public Task<CancelBookingViewModel?> Handle(CancelBookingCommand editCancelBookingCommand,
        CancellationToken cancellationToken)
    {
        return _bookingDetailService.CancelBookingAsync(editCancelBookingCommand.CancelDetailsViewModel,
            cancellationToken);
    }
}