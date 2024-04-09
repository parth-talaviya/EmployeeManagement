namespace UserManagement.Application.Queries.Booking;

public sealed record GetBookingByIdQuery(int Id) : IRequest<GetBookingByIdViewModel>;