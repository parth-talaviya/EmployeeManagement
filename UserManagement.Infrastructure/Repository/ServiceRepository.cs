namespace UserManagement.Infrastructure.Repository;

[RegisterService(typeof(IServiceRepository))]
public sealed class ServiceRepository : IServiceRepository
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public ServiceRepository(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<ServiceDetails?> AddServiceDetailAsync(ServiceDetails serviceDetails,
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.AddParameters(new
        {
            serviceDetails.Name,
        });

        var result = await connection
            .QuerySingleOrDefaultAsync<ServiceDetails>("AddService", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);

        return result;
    }

    public async Task<ServiceDetails?> EditServiceDetailAsync(ServiceDetails serviceDetails,
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.AddParameters(new
        {
            serviceDetails.Id,
            serviceDetails.Name
        });

        return await connection
            .QueryFirstOrDefaultAsync<ServiceDetails>("EditService", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<ServiceDetails?> DeleteServiceDetailAsync(int id, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);

        return await connection
            .QueryFirstOrDefaultAsync<ServiceDetails>("DeleteService", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<IEnumerable<ServiceDetails>> GetAllServiceDetailAsync(CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);


        return await connection.QueryAsync<ServiceDetails>("GetAllService",
            commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }


    public async Task<ServiceDetails?> GetServiceDetailAsync(int id, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);

        return await connection
            .QueryFirstOrDefaultAsync<ServiceDetails>("GetServiceById", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<IEnumerable<ServiceDetails>> GetAllServiceDetailWithLocationIdAndOrganizationIdAsync(
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var serviceDetails = await connection
            .QueryAsync<ServiceDetails, LocationDetails, Organization, ServiceDetails>(
                "GetServiceByLocationAndOrganization",
                (service, location, organization) =>
                {
                    service.Location = location;
                    service.Organization = organization;
                    return service;
                },
                commandType: CommandType.StoredProcedure)
            .ConfigureAwait(false);

        return serviceDetails;
    }

    public async Task<IEnumerable<ServiceDetails>> GetAllServiceDetailWithLocationIdAndOrganizationAndProvidersIdAsync(
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var serviceDetails = await connection
            .QueryAsync<ServiceDetails, LocationDetails, Organization, ProvidersDetails, ServiceDetails>(
                "GetServiceByLocationAndOrganizationAndProviders",
                (service, location, organization, provider) =>
                {
                    service.Location = location;
                    service.Organization = organization;
                    service.Providers = provider;
                    return service;
                },
                commandType: CommandType.StoredProcedure)
            .ConfigureAwait(false);

        return serviceDetails;
    }
}