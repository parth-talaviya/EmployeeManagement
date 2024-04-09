namespace UserManagement.Infrastructure.Repository;

[RegisterService(typeof(ICountryRepository))]

public sealed class CountryRepositroy : ICountryRepository
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public CountryRepositroy(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public async Task<CountryDetails?> AddCountryDetailAsync(CountryDetails countryDetails,
     CancellationToken cancellationToken)
    {
            var connection = _sqlConnectionFactory.CreateConnection();
            await using var _ = connection.ConfigureAwait(false);
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

            var parameters = new DynamicParameters();
            parameters.AddParameters(new
            {
                countryDetails.Name,
                countryDetails.RegionCode,
            });

            var result = await connection
                .QuerySingleOrDefaultAsync<int?>("AddCountry", parameters,
                    commandType: CommandType.StoredProcedure).ConfigureAwait(false);

            if (result.HasValue)
            {
                countryDetails.Id = result.Value;
                return countryDetails;
            }
            else
            {
                return null;
            }
    }


    public async Task<IEnumerable<CountryDetails>> GetAllCountryDetailAsync(CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);


        return await connection.QueryAsync<CountryDetails>("GetAllCountries",
            commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<CountryDetails?> GetCountryDetailAsync(int id, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);

        return await connection
            .QueryFirstOrDefaultAsync<CountryDetails>("GetCountryById", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<CountryDetails?> DeleteCountryDetailAsync(int id, CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.Add("@Id", id);

        return await connection
            .QueryFirstOrDefaultAsync<CountryDetails>("DeleteCountry", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }

    public async Task<CountryDetails?> EditCountryDetailAsync(CountryDetails countryDetails,
        CancellationToken cancellationToken)
    {
        var connection = _sqlConnectionFactory.CreateConnection();
        await using var _ = connection.ConfigureAwait(false);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);

        var parameters = new DynamicParameters();
        parameters.AddParameters(new
        {
            countryDetails.Id,
            countryDetails.Name,
            countryDetails.RegionCode,
        });

        return await connection
            .QueryFirstOrDefaultAsync<CountryDetails>("EditCountry", parameters,
                commandType: CommandType.StoredProcedure).ConfigureAwait(false);
    }
}