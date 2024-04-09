namespace UserManagement.Infrastructure.Repository;

[RegisterService(typeof(IBookingRepository))]
public sealed class BookingRepository : IBookingRepository
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public BookingRepository(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<BookingDetails?> AddBookingDetailAsync(BookingDetails bookDetails,
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.AddParameters(new
        {
            bookDetails.Service,
            bookDetails.Location,
            bookDetails.Organization,
            bookDetails.PhoneNumber,
            bookDetails.Provider,
        });

        var result = await connection
            .QuerySingleOrDefaultAsync<int?>("AddBooking", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);

        bookDetails.Id = (int)result;

        return bookDetails;
    }

    public async Task<IEnumerable<BookingDetails>> GetAllBookingDetailAsync(CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);


        return await connection.QueryAsync<BookingDetails>("GetAllBookings",
            commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<BookingDetails?> GetBookingDetailAsync(int id, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);

        return await connection
            .QueryFirstOrDefaultAsync<BookingDetails>("GetBookingById", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }


    public async Task<IEnumerable<BookingDetails>> GetConfirmBookingDetailAsync(CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);


        return await connection.QueryAsync<BookingDetails>("GetBookingByConfirmBookingStatus",
            commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<BookingDetails?> CancelBookingDetailAsync(BookingDetails bookingDetails,
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.AddParameters(new
        {
            bookingDetails.Id,
        });

        return await connection
            .QueryFirstOrDefaultAsync<BookingDetails>("CancelBooking", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<BookingDetails?> ConfirmBookingDetailAsync(BookingDetails bookingDetails,
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.AddParameters(new
        {
            bookingDetails.Id,
        });

        return await connection
            .QueryFirstOrDefaultAsync<BookingDetails>("ConfirmBooking", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<BookingDetails?> ResheduleBookingDetailAsync(BookingDetails bookingDetails,
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.AddParameters(new
        {
            bookingDetails.Id,
            bookingDetails.Date
        });

        return await connection
            .QueryFirstOrDefaultAsync<BookingDetails>("RescheduleBooking", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }
}