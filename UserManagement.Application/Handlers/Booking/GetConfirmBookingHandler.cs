namespace UserManagement.Application.Handlers.Booking;

public sealed class
    GetConfirmBookingHandler : IRequestHandler<GetConfirmBookingQuery, IEnumerable<GetBookingByIdViewModel>>
{
    private readonly IBookingService _bookingService;

    public GetConfirmBookingHandler(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public async Task<IEnumerable<GetBookingByIdViewModel>> Handle(GetConfirmBookingQuery request,
        CancellationToken cancellationToken)
    {
        return await _bookingService.GetConfirmBookingAsync(cancellationToken).ConfigureAwait(false);
    }
}