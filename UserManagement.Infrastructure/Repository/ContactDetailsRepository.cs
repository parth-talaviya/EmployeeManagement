namespace UserManagement.Infrastructure.Repository;

[RegisterService(typeof(IContactDetailsRepository))]
public sealed class ContactDetailsRepository : IContactDetailsRepository
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public ContactDetailsRepository(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<int> AddContactDetailAsync(ContactDetails contactDetails, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Id", 0, DbType.Int32, direction: ParameterDirection.Output);
        parameters.AddParameters(new
        {
            contactDetails.FirstName,
            contactDetails.MiddleName,
            contactDetails.Email,
            contactDetails.PhoneNumber,
            contactDetails.LastName
        });

        await connection.ExecuteAsync("AddContact", parameters, commandType: CommandType.StoredProcedure)
            .ConfigureAwait(false);
        int newContactId = parameters.Get<int>("@Id");

        return newContactId;
    }

    public async Task<ContactDetails?> DeleteContactDetailAsync(int id, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);

        return await connection
            .QueryFirstOrDefaultAsync<ContactDetails>("DeleteContact", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<ContactDetails?> EditContactDetailAsync(ContactDetails contactDetails,
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.AddParameters(new
        {
            contactDetails.Id,
            contactDetails.FirstName,
            contactDetails.MiddleName,
            contactDetails.Email,
            contactDetails.PhoneNumber,
            contactDetails.LastName
        });

        return await connection
            .QueryFirstOrDefaultAsync<ContactDetails>("EditContact", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<IEnumerable<ContactDetails>> GetAllContactDetailAsync(GetAllContactModel getAllContact,
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.AddParameters(getAllContact);

        return await connection.QueryAsync<ContactDetails>("SearchContactDetailsWithPagination", parameters,
            commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<ContactDetails?> GetContactDetailAsync(int id, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);

        return await connection
            .QueryFirstOrDefaultAsync<ContactDetails>("GetContactDetailsById", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }
}