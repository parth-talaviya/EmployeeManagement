namespace UserManagement.Infrastructure.Repository;

[RegisterService(typeof(IServiceProviderRepository))]
public sealed class ServiceProviderRepository : IServiceProviderRepository
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public ServiceProviderRepository(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<ServiceProviderDetails?> AddServiceProviderDetailAsync(
        ServiceProviderDetails serviceproviderDetails,
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.AddParameters(new
        {
            serviceproviderDetails.ProviderId,
            serviceproviderDetails.ServiceId
        });

        var result = await connection
            .QuerySingleOrDefaultAsync<ServiceProviderDetails>("AddServiceProvider", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);

        return result;
    }

    public async Task<ServiceProviderDetails?> DeleteServiceProviderDetailAsync(int id,
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);

        return await connection
            .QueryFirstOrDefaultAsync<ServiceProviderDetails>("DeleteServiceProvider", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<IEnumerable<ServiceProviderDetails>> GetAllServiceProviderDetailAsync(
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);


        return await connection.QueryAsync<ServiceProviderDetails>("GetAllServiceProviders",
            commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }


    public async Task<ServiceProviderDetails?> GetServiceProviderDetailAsync(int id,
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);

        return await connection
            .QueryFirstOrDefaultAsync<ServiceProviderDetails>("GetServiceProviderByProviderAndServiceId", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }
}