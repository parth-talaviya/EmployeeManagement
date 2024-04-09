namespace UserManagement.Infrastructure.Repository;

[RegisterService(typeof(IOrganizationRepository))]
public sealed class OrganizationRepository : IOrganizationRepository
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public OrganizationRepository(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<int> AddOrganizationAsync(Organization organization, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Id", 0, DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@Name", organization.Name);

        await connection.ExecuteAsync("AddOrganization", parameters, commandType: CommandType.StoredProcedure)
            .ConfigureAwait(false);
        int newOrganizationId = parameters.Get<int>("@Id");

        return newOrganizationId;
    }

    public async Task<Organization?> DeleteOrganizationAsync(int id, CancellationToken cancellationToken)
    {
        using var connection = _sqlConnectionFactory.CreateConnection();
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);

        return await connection
            .QueryFirstOrDefaultAsync<Organization>("DeleteOrganization", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<Organization?> EditOrganizationAsync(Organization organization,
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.AddParameters(new { organization.Name, organization.Id });

        return await connection
            .QueryFirstOrDefaultAsync<Organization>("EditOrganization", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<IEnumerable<Organization>> GetAllOrganizationAsync(CancellationToken cancellationToken)
    {
            var connection = _sqlConnectionFactory.CreateConnection();
            await using var _ = connection.ConfigureAwait(false);
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

            var organizations = await connection
                .QueryAsync<Organization, LocationDetails, Organization>("GetAllOrganizations",
                    (org, loc) =>
                    {
                        org.Location = loc;
                        return org;
                    },
                    commandType: CommandType.StoredProcedure, splitOn: "Id")
                .ConfigureAwait(false);

            return organizations;
    }


    public async Task<Organization?> GetOrganizationAsync(int id, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);
        var organization = await connection
            .QueryAsync<Organization, LocationDetails, Organization>("GetOrganizationById",
                (org, loc) =>
                {
                    org.Location = loc;
                    return org;
                },
                parameters, splitOn: "Id")
            .ConfigureAwait(false);

        return organization.FirstOrDefault();
    }
}