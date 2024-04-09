namespace UserManagement.Application.Handlers.Bookingl;

public sealed class GetBookingByIdHandler : IRequestHandler<GetBookingByIdQuery, GetBookingByIdViewModel?>
{
    private readonly IBookingService _bookingService;

    public GetBookingByIdHandler(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    public Task<GetBookingByIdViewModel?> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
    {
        return _bookingService.GetBookingAsync(request.Id, cancellationToken);
    }
}