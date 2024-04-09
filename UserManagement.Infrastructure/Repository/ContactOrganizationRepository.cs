namespace UserManagement.Infrastructure.Repository;

[RegisterService(typeof(IContactOrganizationRepository))]
public sealed class ContactOrganizationRepository : IContactOrganizationRepository
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public ContactOrganizationRepository(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<int> AddContactOrganizationAsync(ContactOrganization contactOrganization,
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.AddParameters(contactOrganization);
        parameters.Add("@Id", 0, DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@ContactId", contactOrganization.ContactId);
        parameters.Add("@OrganizationId", contactOrganization.OrganizationId);

        await connection
            .QueryFirstOrDefaultAsync<ContactOrganization>("AddContactOrganization", parameters,
                commandType: CommandType.StoredProcedure)
            .ConfigureAwait(false);

        int newContactOrganizationId = parameters.Get<int>("@Id");

        return newContactOrganizationId;
    }

    public async Task<ContactOrganization?> DeleteContactOrganizationAsync(int id, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);

        return await connection
            .QueryFirstOrDefaultAsync<ContactOrganization>("DeleteContactOrganization", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<IEnumerable<ContactOrganization>> GetContactOrganizationAsync(int contactId,
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@ContactId", contactId);

        return await connection.QueryAsync<ContactOrganization>(
            "GetOrganizationByContactId",
            parameters,
            commandType: CommandType.StoredProcedure
        ).ConfigureAwait(false);
    }
}