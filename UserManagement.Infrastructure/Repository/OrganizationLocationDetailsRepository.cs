namespace UserManagement.Infrastructure.Repository;

[RegisterService(typeof(IOrganizationLocationDetailsRepository))]
public sealed class OrganizationLocationDetailsRepository : IOrganizationLocationDetailsRepository
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public OrganizationLocationDetailsRepository(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<LocationDetails?> AddLocationDetailAsync(LocationDetails locationDetails,
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.AddParameters(new
        {
            locationDetails.Country,
            locationDetails.State,
            locationDetails.City,
            locationDetails.Street
        });

        var result = await connection
            .QuerySingleOrDefaultAsync<int?>("AddOrganizationLocation", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);

        if (result.HasValue && result.Value > 0)
        {
            locationDetails.Id = result.Value;
            return locationDetails;
        }
        else
        {
            return null;
        }
    }

    public async Task<LocationDetails?> EditLocationDetailAsync(LocationDetails locationDetails,
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.AddParameters(new
        {
            locationDetails.Id,
            locationDetails.Country,
            locationDetails.State,
            locationDetails.City,
            locationDetails.Street
        });

        return await connection
            .QueryFirstOrDefaultAsync<LocationDetails>("EditOrganizationLocation", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<LocationDetails?> DeleteLocationDetailAsync(int id, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);

        return await connection
            .QueryFirstOrDefaultAsync<LocationDetails>("DeleteOrganizationLocation", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<IEnumerable<LocationDetails>> GetAllLocationDetailAsync(CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);


        return await connection.QueryAsync<LocationDetails>("GetAllOrganizationLocation",
            commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }


    public async Task<LocationDetails?> GetLocationDetailAsync(int id, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);

        return await connection
            .QueryFirstOrDefaultAsync<LocationDetails>("GetOrganizationLocationById", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }
}