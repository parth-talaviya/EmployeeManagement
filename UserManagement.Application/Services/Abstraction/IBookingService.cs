namespace UserManagement.Application.Services.Abstraction;

public interface IBookingService
{
    Task<AddBookingDetailsViewModel?> AddBookingAsync(AddBookingDetailsViewModel bookingViewModel,
        CancellationToken cancellationToken);

    Task<IEnumerable<GetAllBookingViewModel>> GetAllBookingAsync(
        CancellationToken cancellationToken);

    Task<GetBookingByIdViewModel?> GetBookingAsync(int id, CancellationToken cancellationToken);

    Task<IEnumerable<GetBookingByIdViewModel>> GetConfirmBookingAsync(
        CancellationToken cancellationToken);

    Task<CancelBookingViewModel?> CancelBookingAsync(
        CancelBookingViewModel cancelBookingViewModel, CancellationToken cancellationToken);

    Task<ConfirmBookingViewModel?> ConfirmBookingAsync(
        ConfirmBookingViewModel confirmBookingViewModel, CancellationToken cancellationToken);

    Task<ResheduleBookingViewModel?> ResheduleBookingAsync(
        ResheduleBookingViewModel resheduleBookingViewModel, CancellationToken cancellationToken);
}