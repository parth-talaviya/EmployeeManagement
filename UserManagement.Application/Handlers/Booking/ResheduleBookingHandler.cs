namespace UserManagement.Application.Handlers.Booking;

public sealed class ResheduleBookingHandler : IRequestHandler<ResheduleBookingCommand, ResheduleBookingViewModel?>
{
    private readonly IBookingService _bookingDetailService;

    public ResheduleBookingHandler(IBookingService bookingDetailService)
    {
        _bookingDetailService = bookingDetailService;
    }

    public Task<ResheduleBookingViewModel?> Handle(ResheduleBookingCommand resheduleBookingCommand,
        CancellationToken cancellationToken)
    {
        return _bookingDetailService.ResheduleBookingAsync(resheduleBookingCommand.ResheduleDetailsViewModel,
            cancellationToken);
    }
}