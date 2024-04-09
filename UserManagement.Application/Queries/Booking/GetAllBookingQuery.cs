namespace UserManagement.Application.Queries.Booking;

public sealed record GetAllBookingQuery : IRequest<IEnumerable<GetAllBookingViewModel>>;