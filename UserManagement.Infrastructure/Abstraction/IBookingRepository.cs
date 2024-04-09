namespace UserManagement.Infrastructure.Abstraction;

public interface IBookingRepository
{
    Task<BookingDetails?> AddBookingDetailAsync(BookingDetails bookDetails,
        CancellationToken cancellationToken);

    Task<IEnumerable<BookingDetails>> GetAllBookingDetailAsync(CancellationToken cancellationToken);

    Task<BookingDetails?> GetBookingDetailAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<BookingDetails>> GetConfirmBookingDetailAsync(CancellationToken cancellationToken);

    Task<BookingDetails?> CancelBookingDetailAsync(BookingDetails bookingDetails,
        CancellationToken cancellationToken);

    Task<BookingDetails?> ConfirmBookingDetailAsync(BookingDetails bookingDetails,
        CancellationToken cancellationToken);

    Task<BookingDetails?> ResheduleBookingDetailAsync(BookingDetails bookingDetails,
        CancellationToken cancellationToken);
}