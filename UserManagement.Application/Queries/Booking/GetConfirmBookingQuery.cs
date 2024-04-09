namespace UserManagement.Application.Queries.Booking;

public sealed record GetConfirmBookingQuery : IRequest<IEnumerable<GetBookingByIdViewModel>>;