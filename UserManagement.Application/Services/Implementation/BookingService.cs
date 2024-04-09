namespace UserManagement.Application.Services.Implementation;

[RegisterService(typeof(IBookingService))]
public sealed class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingDetailsRepository;
    private readonly IMapper _mapper;

    public BookingService(IBookingRepository bookingRegisterRepository,
        IMapper mapper)
    {
        _bookingDetailsRepository = bookingRegisterRepository;
        _mapper = mapper;
    }

    public async Task<AddBookingDetailsViewModel?> AddBookingAsync(AddBookingDetailsViewModel bookingViewModel,
        CancellationToken cancellationToken)
    {
        var provider = _mapper.Map<AddBookingDetailsViewModel, BookingDetails>(bookingViewModel);
        await _bookingDetailsRepository.AddBookingDetailAsync(provider, cancellationToken)
            .ConfigureAwait(false);

        return bookingViewModel;
    }

    public async Task<IEnumerable<GetAllBookingViewModel>> GetAllBookingAsync(
        CancellationToken cancellationToken)
    {
        var getAllServiceDetail = await _bookingDetailsRepository
            .GetAllBookingDetailAsync(cancellationToken).ConfigureAwait(false);

        return _mapper.Map<IEnumerable<GetAllBookingViewModel>>(getAllServiceDetail) ??
               Enumerable.Empty<GetAllBookingViewModel>();
    }

    public async Task<GetBookingByIdViewModel?> GetBookingAsync(int id, CancellationToken cancellationToken)
    {
        var getProvider = await _bookingDetailsRepository.GetBookingDetailAsync(id, cancellationToken)
            .ConfigureAwait(false);

        return getProvider != null ? _mapper.Map<GetBookingByIdViewModel>(getProvider) : null;
    }

    public async Task<IEnumerable<GetBookingByIdViewModel>> GetConfirmBookingAsync(
        CancellationToken cancellationToken)
    {
        var getAllServiceDetail = await _bookingDetailsRepository
            .GetConfirmBookingDetailAsync(cancellationToken).ConfigureAwait(false);

        return _mapper.Map<IEnumerable<GetBookingByIdViewModel>>(getAllServiceDetail) ??
               Enumerable.Empty<GetBookingByIdViewModel>();
    }

    public async Task<CancelBookingViewModel?> CancelBookingAsync(
        CancelBookingViewModel cancelBookingViewModel, CancellationToken cancellationToken)
    {
        var editCancelBooking = _mapper.Map<CancelBookingViewModel, BookingDetails>(cancelBookingViewModel);
        var cancelBooking = await _bookingDetailsRepository
            .CancelBookingDetailAsync(editCancelBooking, cancellationToken)
            .ConfigureAwait(false);

        return cancelBooking != null
            ? _mapper.Map<BookingDetails, CancelBookingViewModel>(cancelBooking)
            : null;
    }

    public async Task<ConfirmBookingViewModel?> ConfirmBookingAsync(
        ConfirmBookingViewModel confirmBookingViewModel, CancellationToken cancellationToken)
    {
        var editConfirmBooking = _mapper.Map<ConfirmBookingViewModel, BookingDetails>(confirmBookingViewModel);
        var confirmBooking = await _bookingDetailsRepository
            .ConfirmBookingDetailAsync(editConfirmBooking, cancellationToken)
            .ConfigureAwait(false);

        return confirmBooking != null
            ? _mapper.Map<BookingDetails, ConfirmBookingViewModel>(confirmBooking)
            : null;
    }

    public async Task<ResheduleBookingViewModel?> ResheduleBookingAsync(
        ResheduleBookingViewModel resheduleBookingViewModel, CancellationToken cancellationToken)
    {
        var editResheduleBooking = _mapper.Map<ResheduleBookingViewModel, BookingDetails>(resheduleBookingViewModel);
        var resheduleBooking = await _bookingDetailsRepository
            .ResheduleBookingDetailAsync(editResheduleBooking, cancellationToken)
            .ConfigureAwait(false);

        return resheduleBooking != null
            ? _mapper.Map<BookingDetails, ResheduleBookingViewModel>(resheduleBooking)
            : null;
    }
}