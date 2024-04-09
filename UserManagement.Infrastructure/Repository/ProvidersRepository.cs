namespace UserManagement.Infrastructure.Repository;

[RegisterService(typeof(IProvidersRepository))]
public sealed class ProvidersRepository : IProvidersRepository
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public ProvidersRepository(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<ProvidersDetails?> AddProviderDetailAsync(ProvidersDetails providerDetails,
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.AddParameters(new
        {
            providerDetails.ProviderName,
        });

        var result = await connection
            .QuerySingleOrDefaultAsync<ProvidersDetails>("AddProvider", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);

        return result;
    }

    public async Task<ProvidersDetails?> EditProviderDetailAsync(ProvidersDetails providerDetails,
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.AddParameters(new
        {
            providerDetails.Id,
            providerDetails.ProviderName
        });

        return await connection
            .QueryFirstOrDefaultAsync<ProvidersDetails>("EditProvider", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<ProvidersDetails?> DeleteProviderDetailAsync(int id, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);

        return await connection
            .QueryFirstOrDefaultAsync<ProvidersDetails>("DeleteProvider", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<IEnumerable<ProvidersDetails>> GetAllProviderDetailAsync(CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);


        return await connection.QueryAsync<ProvidersDetails>("GetAllProviders",
            commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }


    public async Task<ProvidersDetails?> GetProviderDetailAsync(int id, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);

        return await connection
            .QueryFirstOrDefaultAsync<ProvidersDetails>("GetProviderById", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<IEnumerable<ProvidersDetails>>
        GetspecifcProviderDetailWithServiceOrganizationAndOrganizationAsync(CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var serviceDetails = await connection.QueryAsync<ProvidersDetails, ServiceDetails, LocationDetails, Organization, ProvidersDetails>(
                "GetProvidersWithServiceLocationAndOrganization",
                (provider, service, location, organization) =>
                {
                    provider.Service = service;
                    provider.Location = location;
                    provider.Organization = organization;
                    return provider;
                },
                splitOn: "Id",
                commandType: CommandType.StoredProcedure)
                .ConfigureAwait(false);

        return serviceDetails;
    }

    public async Task<IEnumerable<ProvidersDetails>> GetspecifcProviderDetailWithOrganizationAndLocationAsync(
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var serviceDetails = await connection
            .QueryAsync<ProvidersDetails, LocationDetails, Organization, ProvidersDetails>(
                "GetProvidersWithOrganizationAndLocation",
                (provider, location, organization) =>
                {
                    provider.Location = location;
                    provider.Organization = organization;
                    return provider;
                },
                commandType: CommandType.StoredProcedure)
            .ConfigureAwait(false);

        return serviceDetails;
    }
}