namespace UserManagement.Application.Handlers.Booking;

public sealed class GetAllBookingHandler : IRequestHandler<GetAllBookingQuery, IEnumerable<GetAllBookingViewModel>>
{
    private readonly IBookingService _bookingService;

    public GetAllBookingHandler(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public async Task<IEnumerable<GetAllBookingViewModel>> Handle(GetAllBookingQuery request,
        CancellationToken cancellationToken)
    {
        return await _bookingService.GetAllBookingAsync(cancellationToken).ConfigureAwait(false);
    }
}